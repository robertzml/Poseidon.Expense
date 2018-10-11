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
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Core.Utility;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 电表查询模块
    /// </summary>
    public partial class ElectricMeterTraceModule : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 当前关联账户
        /// </summary>
        private ExpenseAccount currentAccount;

        /// <summary>
        /// 用电记录
        /// </summary>
        private List<ElectricExpenseRecord> electricRecords;
        #endregion //Field

        #region Constructor
        public ElectricMeterTraceModule()
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
            this.bsMeter.DataSource = this.currentAccount.ElectricMeters;
            this.recordGrid.Init();
        }

        /// <summary>
        /// 显示表具信息
        /// </summary>
        /// <param name="meter"></param>
        private void DisplayMeterInfo(ElectricMeter meter)
        {
            this.txtExpenseAccountName.Text = this.currentAccount.Name;
            this.txtMeterName.Text = meter.Name;
            this.txtMeterNumber.Text = meter.Number;
            this.txtAccountName.Text = meter.AccountName;
            this.txtMultiple.Text = meter.Multiple.ToString();
            this.txtSectionNumber.Text = meter.SectionNumber;
            this.txtAddress.Text = meter.Address;
            this.txtRemark.Text = meter.Remark;
        }

        /// <summary>
        /// 显示记录
        /// </summary>
        /// <param name="meter"></param>
        private void DisplayRecords(ElectricMeter meter)
        {
            var expenses = BusinessFactory<ElectricExpenseBusiness>.Instance.FindByAccount(this.currentAccount.Id).OrderByDescending(r => r.BelongDate);

            List<ElectricExpenseRecord> records = new List<ElectricExpenseRecord>();
            foreach (var expense in expenses)
            {
                var rec = expense.Records.Where(r => r.MeterName == meter.Name && r.MeterNumber == meter.Number).ToList();
                rec.ForEach(r => r.Id = expense.BelongDate.ToString());
                records.AddRange(rec);
            }

            this.electricRecords = records;
            this.recordGrid.DataSource = records;
        }

        /// <summary>
        /// 显示趋势
        /// </summary>
        /// <param name="meter"></param>
        private async void DisplayTrend(ElectricMeter meter)
        {
            this.trendChart.Clear();
            var task = Task.Run(() =>
            {
                List<ExpenseDataModel> model = new List<ExpenseDataModel>();
                foreach (var item in this.electricRecords)
                {
                    ExpenseDataModel m = new ExpenseDataModel();
                    m.BelongDate = Convert.ToDateTime(item.Id);
                    m.Quantum = item.Quantity;
                    m.Amount = item.Amount;

                    model.Add(m);
                }

                return model;
            });

            var result = await task;

            this.trendChart.SetChartTitle($"{meter.Name}用能趋势");
            this.trendChart.SetSeriesName(0, "用电量(度)");
            this.trendChart.SetSeriesName(1, "金额", false);
            this.trendChart.SetShowRange(10);
            this.trendChart.SetLabelVisible(true);
            this.trendChart.DataSource = result;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置关联账户
        /// </summary>
        /// <param name="account"></param>
        public void SetAccount(ExpenseAccount account)
        {
            this.currentAccount = account;
            InitControls();
        }

        /// <summary>
        /// 清空显示
        /// </summary>
        public void Clear()
        {
            this.bsMeter.DataSource = null;

            this.txtExpenseAccountName.Text = "";
            this.txtMeterName.Text = "";
            this.txtMeterNumber.Text = "";
            this.txtAccountName.Text = "";
            this.txtMultiple.Text = "";
            this.txtSectionNumber.Text = "";
            this.txtAddress.Text = "";
            this.txtRemark.Text = "";

            this.recordGrid.Clear();
            this.trendChart.Clear();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 表具选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luMeter_EditValueChanged(object sender, EventArgs e)
        {
            if (this.luMeter.EditValue == null)
                return;

            var meter = this.luMeter.GetSelectedDataRow() as ElectricMeter;
            DisplayMeterInfo(meter);
            DisplayRecords(meter);
            DisplayTrend(meter);
        }
        #endregion //Event
    }
}
