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
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Core.Utility;
    using Poseidon.Expense.ClientDx.Model;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 分组费用支出组件
    /// </summary>
    public partial class GroupExpenseModule : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 当前关联分组
        /// </summary>
        private Group currentGroup;

        /// <summary>
        /// 今年
        /// </summary>
        private int nowYear;
        #endregion //Field

        #region Constructor
        public GroupExpenseModule()
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
            this.txtGroupName.Text = "";
            this.txtRemark.Text = "";

            this.currentYearElectricGrid.Clear();
            this.currentYearWaterGrid.Clear();

            this.electricYearGridMod.Clear();
            this.waterYearGridMod.Clear();
            this.gasYearGridMod.Clear();
            this.hotWaterYearGridMod.Clear();

            this.electricYearChartMod.Clear();
            this.waterYearChartMod.Clear();
            this.gasYearChartMod.Clear();
        }

        /// <summary>
        /// 显示摘要
        /// </summary>
        /// <param name="group"></param>
        private async void DisplaySummary(Group group)
        {
            this.txtGroupName.Text = group.Name;
            this.txtRemark.Text = group.Remark;

            var items = BusinessFactory<GroupBusiness>.Instance.FindAllItems(group.Id);

            var task1 = Task.Run(() =>
            {
                List<EnergyExpense> data = new List<EnergyExpense>();

                foreach (var item in items)
                {
                    var expense = BusinessFactory<ElectricExpenseBusiness>.Instance.FindYearByAccount(item.EntityId, nowYear);
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

            var data1 = await task1;
            this.currentYearElectricGrid.ShowUnitPrice = false;
            this.currentYearElectricGrid.ShowAddition("功率因数奖(元)");
            this.currentYearElectricGrid.DataSource = data1;

            this.electricYearChart.SetChartTitle(string.Format("{0}{1}年电量消耗", group.Name, this.nowYear));
            this.electricYearChart.SetSeriesName(0, "用量(度)");
            this.electricYearChart.SetSeriesName(1, "金额(元)");
            this.electricYearChart.SetDataSource(data1);

            var task2 = Task.Run(() =>
            {
                List<EnergyExpense> waterData = new List<EnergyExpense>();
                foreach (var item in items)
                {
                    var expense = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(item.EntityId, nowYear);
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

                            waterData.Add(model);
                        }
                    }
                }

                return waterData;
            });

            var data2 = await task2;
            this.currentYearWaterGrid.ShowUnitPrice = true;
            this.currentYearWaterGrid.DataSource = data2;

            this.waterYearChart.SetChartTitle(string.Format("{0}{1}年水量消耗", group.Name, this.nowYear));
            this.waterYearChart.SetSeriesName(0, "用量(吨)");
            this.waterYearChart.SetSeriesName(1, "金额(元)");
            this.waterYearChart.SetDataSource(data2);
        }

        /// <summary>
        /// 显示年度汇总
        /// </summary>
        /// <param name="group"></param>
        private void DisplayYear(Group group)
        {
            this.electricYearGridMod.SetGroup(this.currentGroup, EnergyExpenseType.Electric);
            this.waterYearGridMod.SetGroup(this.currentGroup, EnergyExpenseType.Water);
            this.gasYearGridMod.SetGroup(this.currentGroup, EnergyExpenseType.Gas);
            this.hotWaterYearGridMod.SetGroup(this.currentGroup, EnergyExpenseType.HotWater);

            this.electricYearChartMod.SetGroup(this.currentGroup, EnergyExpenseType.Electric);
            this.waterYearChartMod.SetGroup(this.currentGroup, EnergyExpenseType.Water);
            this.gasYearChartMod.SetGroup(this.currentGroup, EnergyExpenseType.Gas);
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置关联分组
        /// </summary>
        /// <param name="id">分组ID</param>
        public void SetGroup(string id)
        {
            this.currentGroup = BusinessFactory<GroupBusiness>.Instance.FindById(id);
            this.nowYear = DateTime.Now.Year;

            ClearDisplay();
            DisplaySummary(this.currentGroup);
            DisplayYear(this.currentGroup);
        }
        #endregion //Method
    }
}
