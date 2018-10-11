using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Expense.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Expense.ClientDx.Model;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 年度支出图表模块
    /// </summary>
    public partial class ExpenseDataYearChartCtrl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 当前关联账户
        /// </summary>
        private ExpenseAccount currentAccount;

        /// <summary>
        /// 当前关联分组
        /// </summary>
        private Group currentGroup;

        /// <summary>
        /// 能源类型
        /// </summary>
        private EnergyExpenseType energyType;

        private int startYear = 2011;

        private int nowYear;

        /// <summary>
        /// 显示类型  1:部门  2:分组
        /// </summary>
        private int showType;
        #endregion //Field

        #region Constructor
        public ExpenseDataYearChartCtrl()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            this.cmbYear.Properties.Items.Clear();

            for (int i = nowYear; i >= startYear; i--)
            {
                this.cmbYear.Properties.Items.Add(i.ToString() + "年");
            }

            this.cmbYear.SelectedIndex = 0;
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="account">支出账户</param>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        private void LoadAccountData(ExpenseAccount account, int year, EnergyExpenseType energyType)
        {
            IExpenseData handle = null;
            switch (energyType)
            {
                case EnergyExpenseType.Electric:
                    handle = BusinessFactory<ElectricExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{account.Name}{year}年用电情况");
                    this.expenseChart.SetSeriesName(0, "用量(度)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                case EnergyExpenseType.Water:
                    handle = BusinessFactory<WaterExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{account.Name}{year}年用水情况");
                    this.expenseChart.SetSeriesName(0, "用量(吨)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                case EnergyExpenseType.Gas:
                    handle = BusinessFactory<GasExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{account.Name}{year}年用气情况");
                    this.expenseChart.SetSeriesName(0, "用量(立方)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                case EnergyExpenseType.HotWater:
                    handle = BusinessFactory<HotWaterExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{account.Name}{year}年热水情况");
                    this.expenseChart.SetSeriesName(0, "用量(吨)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                default:
                    return;
            }

            var data = handle.GetExpenseDataModel(account.Id, year).ToList();
            this.expenseChart.SetDataSource(data);
        }

        /// <summary>
        /// 载入分组数据
        /// </summary>
        /// <param name="group">分组</param>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        private async void LoadGroupData(Group group, int year, EnergyExpenseType energyType)
        {
            IExpenseData handle = null;
            switch (energyType)
            {
                case EnergyExpenseType.Electric:
                    handle = BusinessFactory<ElectricExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{group.Name}{year}年用电情况");
                    this.expenseChart.SetSeriesName(0, "用量(度)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                case EnergyExpenseType.Water:
                    handle = BusinessFactory<WaterExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{group.Name}{year}年用水情况");
                    this.expenseChart.SetSeriesName(0, "用量(吨)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                case EnergyExpenseType.Gas:
                    handle = BusinessFactory<GasExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{group.Name}{year}年用气情况");
                    this.expenseChart.SetSeriesName(0, "用量(立方)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                case EnergyExpenseType.HotWater:
                    handle = BusinessFactory<HotWaterExpenseBusiness>.Instance;
                    this.expenseChart.SetChartTitle($"{group.Name}{year}年热水情况");
                    this.expenseChart.SetSeriesName(0, "用量(吨)");
                    this.expenseChart.SetSeriesName(1, "金额(元)");
                    break;
                default:
                    return;
            }

            var task = Task.Run(() =>
            {
                List<ExpenseDataModel> data = new List<ExpenseDataModel>();

                var items = BusinessFactory<GroupBusiness>.Instance.FindAllItems(group.Id);
                foreach (var item in items)
                {
                    var expenseData = handle.GetExpenseDataModel(item.EntityId, year);
                    foreach (var exp in expenseData)
                    {
                        var find = data.SingleOrDefault(r => r.BelongDate == exp.BelongDate);
                        if (find != null)
                        {
                            find.Amount += exp.Amount;
                            find.Quantum += exp.Quantum;
                            find.AdditionData += exp.AdditionData;
                        }
                        else
                        {
                            var model = new ExpenseDataModel();
                            model.Name = exp.Name;
                            model.BelongDate = exp.BelongDate;
                            model.Quantum = exp.Quantum;
                            model.Amount = exp.Amount;
                            model.UnitPrice = exp.UnitPrice;
                            model.AdditionData = exp.AdditionData;

                            data.Add(model);
                        }
                    }
                }

                return data;
            });

            var result = await task;
            this.expenseChart.SetDataSource(result);
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置账户
        /// </summary>
        /// <param name="account">支出账户</param>
        /// <param name="energyType">能源类型</param>
        public void SetAccount(ExpenseAccount account, EnergyExpenseType energyType)
        {
            this.currentAccount = account;
            this.energyType = energyType;
            this.showType = 1;
            this.nowYear = DateTime.Now.Year;

            InitControls();
        }

        /// <summary>
        /// 设置分组
        /// </summary>
        /// <param name="group">分组</param>
        /// <param name="energyType">能源类型</param>
        public void SetGroup(Group group, EnergyExpenseType energyType)
        {
            this.currentGroup = group;
            this.energyType = energyType;
            this.nowYear = DateTime.Now.Year;
            this.showType = 2;

            InitControls();
        }

        /// <summary>
        /// 清空显示
        /// </summary>
        public void Clear()
        {
            this.cmbYear.EditValue = "";
            this.expenseChart.Clear();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 年度选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbYear.SelectedIndex == -1)
                return;

            int year = Convert.ToInt32(this.cmbYear.SelectedItem.ToString().Substring(0, 4));
            if (this.showType == 1)
                LoadAccountData(this.currentAccount, year, this.energyType);
            else if (this.showType == 2)
                LoadGroupData(this.currentGroup, year, this.energyType);
        }
        #endregion //Event
    }
}
