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
    /// 年度支出模块
    /// </summary>
    public partial class ExpenseYearModule : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
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
        public ExpenseYearModule()
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
        private async void LoadAccountData(ExpenseAccount account, int year, EnergyExpenseType energyType)
        {
            switch (energyType)
            {
                case EnergyExpenseType.Electric:
                    var data1 = await LoadElectric(account, year);
                    this.expenseGrid.ShowUnitPrice = false;
                    this.expenseGrid.ShowAddition("功率因数奖(元)");
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Electric);
                    this.expenseGrid.DataSource = data1;
                    break;
                case EnergyExpenseType.Water:
                    var data2 = await LoadWater(account, year);
                    this.expenseGrid.ShowUnitPrice = true;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Water);
                    this.expenseGrid.DataSource = data2;
                    break;
                case EnergyExpenseType.Gas:
                    var data3 = await LoadGas(account, year);
                    this.expenseGrid.ShowUnitPrice = true;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Gas);
                    this.expenseGrid.DataSource = data3;
                    break;
            }
        }

        /// <summary>
        /// 载入分组数据
        /// </summary>
        /// <param name="group">分组</param>
        /// <param name="year">年度</param>
        /// <param name="energyType">能源类型</param>
        private async void LoadGroupData(Group group, int year, EnergyExpenseType energyType)
        {
            switch (energyType)
            {
                case EnergyExpenseType.Electric:
                    var data1 = await LoadElectric(group, year);
                    this.expenseGrid.ShowUnitPrice = false;
                    this.expenseGrid.ShowAddition("功率因数奖(元)");
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Electric);
                    this.expenseGrid.DataSource = data1;
                    break;
                case EnergyExpenseType.Water:
                    var data2 = await LoadWater(group, year);
                    this.expenseGrid.ShowUnitPrice = true;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Water);
                    this.expenseGrid.DataSource = data2;
                    break;
                case EnergyExpenseType.Gas:
                    var data3 = await LoadGas(group, year);
                    this.expenseGrid.ShowUnitPrice = true;
                    this.expenseGrid.SetEnergyType(EnergyExpenseType.Gas);
                    this.expenseGrid.DataSource = data3;
                    break;
            }
        }

        /// <summary>
        /// 载入电费支出
        /// </summary>
        /// <param name="account"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private async Task<List<EnergyExpense>> LoadElectric(ExpenseAccount account, int year)
        {
            var task = Task.Run(() =>
            {
                List<EnergyExpense> electricData = new List<EnergyExpense>();
                var electricExpense = BusinessFactory<ElectricExpenseBusiness>.Instance.FindYearByAccount(account.Id, year);

                foreach (var exp in electricExpense)
                {
                    var model = new EnergyExpense();
                    model.BelongDate = exp.BelongDate;
                    model.Quantum = exp.TotalQuantity;
                    model.Amount = exp.TotalAmount;
                    model.AdditionData = exp.TotalPrize;

                    electricData.Add(model);
                }
                return electricData;
            });

            return await task;
        }

        /// <summary>
        /// 载入电费支出
        /// </summary>
        /// <param name="group"></param>
        /// <param name="year"></param>
        private async Task<List<EnergyExpense>> LoadElectric(Group group, int year)
        {
            var task = Task.Run(() =>
            {
                var items = BusinessFactory<GroupBusiness>.Instance.FindAllItems(group.Id);

                List<EnergyExpense> data = new List<EnergyExpense>();

                foreach (var item in items)
                {
                    var expense = BusinessFactory<ElectricExpenseBusiness>.Instance.FindYearByAccount(item.EntityId, year);
                    foreach (var exp in expense)
                    {
                        var energyExpense = data.SingleOrDefault(r => r.BelongDate == exp.BelongDate);
                        if (energyExpense != null)
                        {
                            energyExpense.Amount += exp.TotalAmount;
                            energyExpense.Quantum += exp.TotalQuantity;
                            energyExpense.AdditionData += exp.TotalPrize;
                        }
                        else
                        {
                            var model = new EnergyExpense();
                            model.BelongDate = exp.BelongDate;
                            model.Quantum = exp.TotalQuantity;
                            model.Amount = exp.TotalAmount;
                            model.AdditionData = exp.TotalPrize;

                            data.Add(model);
                        }
                    }
                }

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 载入水费支出
        /// </summary>
        /// <param name="account"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private async Task<List<EnergyExpense>> LoadWater(ExpenseAccount account, int year)
        {
            var task = Task.Run(() =>
            {
                List<EnergyExpense> expenseData = new List<EnergyExpense>();
                var waterExpense = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(account.Id, year);

                foreach (var exp in waterExpense)
                {
                    var model = new EnergyExpense();
                    model.BelongDate = exp.BelongDate;
                    model.Quantum = exp.TotalQuantity;
                    model.Amount = exp.TotalAmount;
                    model.UnitPrice = exp.TotalAmount / exp.TotalQuantity;

                    expenseData.Add(model);
                }
                return expenseData;
            });

            return await task;
        }

        /// <summary>
        /// 载入水费支出
        /// </summary>
        /// <param name="group"></param>
        /// <param name="year"></param>
        private async Task<List<EnergyExpense>> LoadWater(Group group, int year)
        {
            var task = Task.Run(() =>
            {
                var items = BusinessFactory<GroupBusiness>.Instance.FindAllItems(group.Id);

                List<EnergyExpense> waterData = new List<EnergyExpense>();
                foreach (var item in items)
                {
                    var expense = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(item.EntityId, year);
                    foreach (var exp in expense)
                    {
                        var energyExpense = waterData.SingleOrDefault(r => r.BelongDate == exp.BelongDate);
                        if (energyExpense != null)
                        {
                            energyExpense.Amount += exp.TotalAmount;
                            energyExpense.Quantum += exp.TotalQuantity;
                        }
                        else
                        {
                            var model = new EnergyExpense();
                            model.BelongDate = exp.BelongDate;
                            model.Quantum = exp.TotalQuantity;
                            model.Amount = exp.TotalAmount;
                            model.UnitPrice = exp.TotalAmount / exp.TotalQuantity;

                            waterData.Add(model);
                        }
                    }
                }

                return waterData;
            });

            return await task;
        }

        /// <summary>
        /// 载入气费支出
        /// </summary>
        /// <param name="account"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private async Task<List<EnergyExpense>> LoadGas(ExpenseAccount account, int year)
        {
            var task = Task.Run(() =>
            {
                List<EnergyExpense> expenseData = new List<EnergyExpense>();
                var waterExpense = BusinessFactory<GasExpenseBusiness>.Instance.FindYearByAccount(account.Id, year);

                foreach (var exp in waterExpense)
                {
                    var model = new EnergyExpense();
                    model.BelongDate = exp.BelongDate;
                    model.Quantum = exp.TotalQuantity;
                    model.Amount = exp.TotalAmount;
                    model.UnitPrice = exp.TotalAmount / exp.TotalQuantity;

                    expenseData.Add(model);
                }
                return expenseData;
            });

            return await task;
        }

        /// <summary>
        /// 载入气费支出
        /// </summary>
        /// <param name="group"></param>
        /// <param name="year"></param>
        private async Task<List<EnergyExpense>> LoadGas(Group group, int year)
        {
            var task = Task.Run(() =>
            {
                var items = BusinessFactory<GroupBusiness>.Instance.FindAllItems(group.Id);

                List<EnergyExpense> gasData = new List<EnergyExpense>();
                foreach (var item in items)
                {
                    var expense = BusinessFactory<GasExpenseBusiness>.Instance.FindYearByAccount(item.EntityId, year);
                    foreach (var exp in expense)
                    {
                        var energyExpense = gasData.SingleOrDefault(r => r.BelongDate == exp.BelongDate);
                        if (energyExpense != null)
                        {
                            energyExpense.Amount += exp.TotalAmount;
                            energyExpense.Quantum += exp.TotalQuantity;
                        }
                        else
                        {
                            var model = new EnergyExpense();
                            model.BelongDate = exp.BelongDate;
                            model.Quantum = exp.TotalQuantity;
                            model.Amount = exp.TotalAmount;
                            model.UnitPrice = exp.TotalAmount / exp.TotalQuantity;

                            gasData.Add(model);
                        }
                    }
                }

                return gasData;
            });

            return await task;
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

            this.expenseGrid.ShowUnitPrice = this.showUnitPrice;
            this.expenseGrid.ShowAddtionData = this.showAdditionData;
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

            this.expenseGrid.ShowUnitPrice = this.showUnitPrice;
            this.expenseGrid.ShowAddtionData = this.showAdditionData;
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
            }
        }
        #endregion //Property
    }
}