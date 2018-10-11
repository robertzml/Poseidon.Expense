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
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 年度支出数据模块
    /// </summary>
    public partial class ExpenseDataYearGridCtrl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 是否显示名称列
        /// </summary>
        private bool showColName = true;

        /// <summary>
        /// 是否显示归属日期列
        /// </summary>
        private bool showColBelongDate = true;

        /// <summary>
        /// 是否显示单价列
        /// </summary>
        private bool showUnitPrice = true;

        /// <summary>
        /// 是否显示附加数据
        /// </summary>
        private bool showAdditionData = false;

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
        public ExpenseDataYearGridCtrl()
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
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Electric, "度");
                    break;
                case EnergyExpenseType.Water:
                    handle = BusinessFactory<WaterExpenseBusiness>.Instance;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Water, "吨");
                    break;
                case EnergyExpenseType.Gas:
                    handle = BusinessFactory<GasExpenseBusiness>.Instance;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Gas, "立方");
                    break;
                case EnergyExpenseType.HotWater:
                    handle = BusinessFactory<HotWaterExpenseBusiness>.Instance;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.HotWater, "吨");
                    break;
                default:
                    return;
            }

            var data = handle.GetExpenseDataModel(account.Id, year).ToList();

            this.expenseGrid.DataSource = data;
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
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Electric, "度");
                    break;
                case EnergyExpenseType.Water:
                    handle = BusinessFactory<WaterExpenseBusiness>.Instance;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Water, "吨");
                    break;
                case EnergyExpenseType.Gas:
                    handle = BusinessFactory<GasExpenseBusiness>.Instance;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Gas, "立方");
                    break;
                case EnergyExpenseType.HotWater:
                    handle = BusinessFactory<HotWaterExpenseBusiness>.Instance;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.HotWater, "吨");
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

                return data.OrderBy(r => r.BelongDate).ToList();
            });

            var result = await task;
            this.expenseGrid.DataSource = result;
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
            this.showType = 2;
            this.nowYear = DateTime.Now.Year;

            InitControls();
        }

        /// <summary>
        /// 清空显示
        /// </summary>
        public void Clear()
        {
            this.cmbYear.EditValue = "";
            this.expenseGrid.Clear();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpenseDataYearGridCtrl_Load(object sender, EventArgs e)
        {
            this.expenseGrid.ShowColName = this.showColName;
            this.expenseGrid.ShowColBelongDate = this.showColBelongDate;
            this.expenseGrid.ShowUnitPrice = this.showUnitPrice;
            this.expenseGrid.ShowAddtionData = this.showAdditionData;
        }

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

        #region Property
        /// <summary>
        /// 是否显示名称列
        /// </summary>
        [Description("是否显示名称列"), Category("界面"), Browsable(true)]
        public bool ShowColName
        {
            get
            {
                return showColName;
            }

            set
            {
                showColName = value;
                this.expenseGrid.ShowColName = value;
            }
        }

        /// <summary>
        /// 是否显示归属日期列
        /// </summary>
        [Description("是否显示归属日期列"), Category("界面"), Browsable(true)]
        public bool ShowColBelongDate
        {
            get
            {
                return showColBelongDate;
            }

            set
            {
                showColBelongDate = value;
                this.expenseGrid.ShowColBelongDate = value;
            }
        }

        /// <summary>
        /// 是否显示单价列
        /// </summary>
        [Description("是否显示单价列"), Category("界面"), Browsable(true)]
        public bool ShowUnitPrice
        {
            get
            {
                return this.showUnitPrice;
            }
            set
            {
                this.showUnitPrice = value;
                this.expenseGrid.ShowUnitPrice = value;
            }
        }

        /// <summary>
        /// 是否显示附加数据
        /// </summary>
        [Description("是否显示附加数据"), Category("界面"), Browsable(true)]
        public bool ShowAddtionData
        {
            get
            {
                return this.showAdditionData;
            }
            set
            {
                this.showAdditionData = value;
                this.expenseGrid.ShowAddtionData = value;
            }
        }
        #endregion //Property
    }
}
