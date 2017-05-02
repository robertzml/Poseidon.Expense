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
    using Poseidon.Common;
    using Poseidon.Expense.ClientDx.Model;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 账户支出模块
    /// </summary>
    public partial class AccountExpenseModule : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 当前关联账户
        /// </summary>
        private ExpenseAccount currentAccount;

        private int startYear = 2011;

        /// <summary>
        /// 今年
        /// </summary>
        private int nowYear;
        #endregion //Field

        #region Constructor
        public AccountExpenseModule()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 清空显示
        /// </summary>
        private void ClearDisplay()
        {
            this.currentYearElectricGrid.Clear();
            this.currentYearWaterGrid.Clear();
            this.currentYearElectricChart.Clear();
            this.currentYearWaterChart.Clear();

            this.electricCompareGridMod.Clear();
            this.electricCompareChartMod.Clear();
            this.waterCompareGridMod.Clear();
            this.waterCompareChartMod.Clear();
            this.gasCompareGridMod.Clear();
            this.gasCompareChartMod.Clear();

            this.electricYearGridMod.Clear();
            this.waterYearGridMod.Clear();
            this.gasYearGridMod.Clear();
            this.electricYearChartMod.Clear();
            this.waterYearChartMod.Clear();
            this.gasYearChartMod.Clear();
        }

        /// <summary>
        /// 载入电摘要
        /// </summary>
        /// <param name="account"></param>
        private async void LoadElectricSummary(ExpenseAccount account)
        {
            //用电
            this.electricMeterGrid.DataSource = account.ElectricMeters;

            var task = Task.Run(() =>
            {
                List<EnergyExpense> electricData = new List<EnergyExpense>();
                var electricExpense = BusinessFactory<ElectricExpenseBusiness>.Instance.FindYearByAccount(account.Id, this.nowYear);

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

            var data = await task;
            this.gcYearGrid1.Text = "本年度用电支出";
            this.currentYearElectricGrid.DataSource = data;
            this.currentYearElectricGrid.ShowAddition("功率因数奖(元)");

            this.gcYearChart1.Text = "本年度用电情况";
            this.currentYearElectricChart.SetChartTitle(string.Format("{0}{1}年电量消耗", account.ShortName, this.nowYear));
            this.currentYearElectricChart.SetDataSource(data);
        }

        /// <summary>
        /// 载入水摘要
        /// </summary>
        /// <param name="account"></param>
        private async void LoadWaterSummary(ExpenseAccount account)
        {
            this.waterMeterGrid.DataSource = account.WaterMeters;

            var task = Task.Run(() =>
            {
                List<EnergyExpense> waterData = new List<EnergyExpense>();
                var waterExpense = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(account.Id, this.nowYear);

                foreach (var exp in waterExpense)
                {
                    var model = new EnergyExpense();
                    model.BelongDate = exp.BelongDate;
                    model.Quantum = exp.TotalQuantity;
                    model.Amount = exp.TotalAmount;

                    waterData.Add(model);
                }

                return waterData;
            });

            var data = await task;
            this.currentYearWaterGrid.DataSource = data;

            this.currentYearWaterChart.SetChartTitle(string.Format("{0}{1}年水量消耗", account.ShortName, this.nowYear));
            this.currentYearWaterChart.SetDataSource(data);
        }

        /// <summary>
        /// 载入气摘要
        /// </summary>
        /// <param name="account"></param>
        private async void LoadGasSummary(ExpenseAccount account)
        {
            this.gasMeterGrid.DataSource = account.GasMeters;

            if (!account.EnergyType.Contains(1)) //利用电位置
            {
                var task = Task.Run(() =>
                {
                    List<EnergyExpense> gasData = new List<EnergyExpense>();
                    var gasExpense = BusinessFactory<GasExpenseBusiness>.Instance.FindYearByAccount(account.Id, this.nowYear);

                    foreach (var exp in gasExpense)
                    {
                        var model = new EnergyExpense();
                        model.BelongDate = exp.BelongDate;
                        model.Quantum = exp.TotalQuantity;
                        model.Amount = exp.TotalAmount;

                        gasData.Add(model);
                    }

                    return gasData;
                });

                var data = await task;
                this.gcYearGrid1.Text = "本年度用气支出";
                this.currentYearElectricGrid.DataSource = data;
                this.currentYearElectricGrid.ShowAddition("", false);

                this.gcYearChart1.Text = "本年度用气情况";
                this.currentYearElectricChart.SetChartTitle($"{account.ShortName}{this.nowYear}年天然气消耗");
                this.currentYearElectricChart.SetDataSource(data);
            }
        }

        /// <summary>
        /// 显示摘要
        /// </summary>
        /// <param name="account"></param>
        private void DisplaySummary(ExpenseAccount account)
        {
            this.ctrAccountInfo.SetAccount(account);

            if (account.EnergyType.Contains(1))
            {
                LoadElectricSummary(account);
            }
            else
            {
                this.electricMeterGrid.DataSource = null;
            }

            //用水
            if (account.EnergyType.Contains(2))
            {
                LoadWaterSummary(account);
            }
            else
            {
                this.waterMeterGrid.DataSource = null;
            }

            //用气
            if (account.EnergyType.Contains(3))
            {
                LoadGasSummary(account);
            }
            else
            {
                this.gasMeterGrid.DataSource = null;
            }
        }

        /// <summary>
        /// 显示单据
        /// </summary>
        /// <param name="account"></param>
        private void DisplayReceipt(ExpenseAccount account)
        {
            if (account.EnergyType.Contains(1))
            {
                this.tabPageElectricReceipt.PageVisible = true;
                this.electricExpenseReceipt.SetAccount(account);
            }
            else
                this.tabPageElectricReceipt.PageVisible = false;

            if (account.EnergyType.Contains(2))
            {
                this.tabPageWaterReceipt.PageVisible = true;
                this.waterExpenseReceipt.SetAccount(account);
            }
            else
                this.tabPageWaterReceipt.PageVisible = false;

            if (account.EnergyType.Contains(3))
            {
                this.tabPageGasReceipt.PageVisible = true;
                this.gasExpenseReceipt.SetAccount(account);
            }
            else
                this.tabPageGasReceipt.PageVisible = false;
        }

        /// <summary>
        /// 显示对比
        /// </summary>
        /// <param name="account"></param>
        private void DisplayCompare(ExpenseAccount account)
        {
            this.electricCompareGridMod.SetAccount(account, EnergyExpenseType.Electric);
            this.electricCompareChartMod.SetAccount(account, EnergyExpenseType.Electric);

            this.waterCompareGridMod.SetAccount(account, EnergyExpenseType.Water);
            this.waterCompareChartMod.SetAccount(account, EnergyExpenseType.Water);

            this.gasCompareGridMod.SetAccount(account, EnergyExpenseType.Gas);
            this.gasCompareChartMod.SetAccount(account, EnergyExpenseType.Gas);
        }

        /// <summary>
        /// 显示年度汇总
        /// </summary>
        /// <param name="account"></param>
        private async void DisplayYear(ExpenseAccount account)
        {
            if (account.EnergyType.Contains(1))
            {
                this.tabPageElectricYear.PageVisible = true;
                var task1 = Task.Run(() =>
                {
                    List<EnergyExpense> data = new List<EnergyExpense>();
                    for (int i = startYear; i <= nowYear; i++)
                    {
                        var yearData = BusinessFactory<ElectricExpenseBusiness>.Instance.FindYearByAccount(account.Id, i);
                        if (yearData.Count() == 0)
                            continue;

                        EnergyExpense energyExpense = new EnergyExpense();
                        energyExpense.BelongDate = new DateTime(i, 1, 1);
                        energyExpense.Quantum = yearData.Sum(r => r.TotalQuantity);
                        energyExpense.Amount = yearData.Sum(r => r.TotalAmount);

                        data.Add(energyExpense);
                    }

                    return data;
                });

                var result1 = await task1;

                this.electricYearChart.SetChartTitle(account.ShortName + "历年用电对比");
                this.electricYearChart.SetSeriesLengedText(0, "用电量(度)");
                this.electricYearChart.DataSource = result1;

                this.electricYearGridMod.SetAccount(this.currentAccount, EnergyExpenseType.Electric);
                this.electricYearChartMod.SetAccount(this.currentAccount, EnergyExpenseType.Electric);
            }
            else
            {
                this.tabPageElectricYear.PageVisible = false;
            }

            if (account.EnergyType.Contains(2))
            {
                this.tabPageWaterYear.PageVisible = true;

                var task2 = Task.Run(() =>
                {
                    List<EnergyExpense> data = new List<EnergyExpense>();
                    for (int i = startYear; i <= nowYear; i++)
                    {
                        var yearData = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(account.Id, i);
                        if (yearData.Count() == 0)
                            continue;

                        EnergyExpense energyExpense = new EnergyExpense();
                        energyExpense.BelongDate = new DateTime(i, 1, 1);
                        energyExpense.Quantum = yearData.Sum(r => r.TotalQuantity);
                        energyExpense.Amount = yearData.Sum(r => r.TotalAmount);

                        data.Add(energyExpense);
                    }
                    return data;
                });

                var result2 = await task2;

                this.waterYearChart.SetChartTitle(account.ShortName + "历年用水对比");
                this.waterYearChart.SetSeriesLengedText(0, "用水量(吨)");
                this.waterYearChart.DataSource = result2;

                this.waterYearGridMod.SetAccount(this.currentAccount, EnergyExpenseType.Water);
                this.waterYearChartMod.SetAccount(this.currentAccount, EnergyExpenseType.Water);
            }
            else
            {
                this.tabPageWaterYear.PageVisible = false;
            }

            if (account.EnergyType.Contains(3))
            {
                this.tabPageGasYear.PageVisible = true;
                var task3 = Task.Run(() =>
                {
                    List<EnergyExpense> data = new List<EnergyExpense>();
                    for (int i = startYear; i <= nowYear; i++)
                    {
                        var yearData = BusinessFactory<GasExpenseBusiness>.Instance.FindYearByAccount(account.Id, i);
                        if (yearData.Count() == 0)
                            continue;

                        EnergyExpense energyExpense = new EnergyExpense();
                        energyExpense.BelongDate = new DateTime(i, 1, 1);
                        energyExpense.Quantum = yearData.Sum(r => r.TotalQuantity);
                        energyExpense.Amount = yearData.Sum(r => r.TotalAmount);

                        data.Add(energyExpense);
                    }
                    return data;
                });

                var result3 = await task3;

                this.gasYearChart.SetChartTitle(account.ShortName + "历年用气对比");
                this.gasYearChart.SetSeriesLengedText(0, "用气量(立方)");
                this.gasYearChart.DataSource = result3;

                this.gasYearGridMod.SetAccount(this.currentAccount, EnergyExpenseType.Gas);
                this.gasYearChartMod.SetAccount(this.currentAccount, EnergyExpenseType.Gas);
            }
            else
            {
                this.tabPageGasYear.PageVisible = false;
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置账户
        /// </summary>
        /// <param name="id">支出账户ID</param>
        public void SetAccount(string id)
        {
            this.currentAccount = BusinessFactory<ExpenseAccountBusiness>.Instance.FindById(id);
            this.nowYear = DateTime.Now.Year;

            ClearDisplay();
            DisplaySummary(this.currentAccount);
            DisplayReceipt(this.currentAccount);
            DisplayCompare(this.currentAccount);
            DisplayYear(this.currentAccount);
        }
        #endregion //Method
    }
}
