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
    using DevExpress.XtraCharts;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 能源支出比较组件
    /// </summary>
    public partial class EnergyCompareChartModule : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 起始年份
        /// </summary>
        private int startYear = 2011;

        private int nowYear;

        /// <summary>
        /// 关联支出账户
        /// </summary>
        private ExpenseAccount currentAccount;

        /// <summary>
        /// 能源支出类型
        /// </summary>
        private EnergyExpenseType energyType;
        #endregion //Field

        #region Constructor
        public EnergyCompareChartModule()
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
            this.ccbYears.Properties.Items.Clear();
            for (int i = nowYear; i >= startYear; i--)
            {
                this.ccbYears.Properties.Items.Add(i.ToString() + "年");
            }

            this.cmbDataType.SelectedIndex = 0;

            if (energyType == EnergyExpenseType.Electric)
                this.energyChart.SetChartTitle(currentAccount.ShortName + "年度用电支出对比");
            else if (energyType == EnergyExpenseType.Water)
                this.energyChart.SetChartTitle(currentAccount.ShortName + "年度用水支出对比");
            else if (energyType == EnergyExpenseType.Gas)
                this.energyChart.SetChartTitle(currentAccount.ShortName + "年度用气支出对比");
        }

        /// <summary>
        /// 获取选择年度
        /// </summary>
        /// <returns></returns>
        private int[] GetSelectYears()
        {
            var yeartext = this.ccbYears.EditValue.ToString();

            if (string.IsNullOrEmpty(yeartext))
                return null;

            var texts = yeartext.Split(',').ToList();

            texts.ForEach(r => r.Trim());
            texts.Sort();

            List<int> years = texts.ConvertAll<int>((r) =>
            {
                return Convert.ToInt32(r.Trim().Substring(0, 4));
            });

            return years.ToArray();
        }

        /// <summary>
        /// 载入用电支出数据
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="years">年度列表</param>
        /// <param name="type">类型</param>
        /// <param name="showLabel">是否显示标签</param>
        private void LoadElectricData(ExpenseAccount account, int[] years, int type, bool showLabel)
        {
            for (int i = 0; i < years.Length; i++)
            {
                int year = years[i];
                string title = $"{year}年";

                var electricExpenses = BusinessFactory<ElectricExpenseBusiness>.Instance.FindYearByAccount(account.Id, year).ToList();

                List<SeriesPoint> points = new List<SeriesPoint>();
                string unit = "";

                for (int j = 0; j < electricExpenses.Count; j++)
                {
                    string month = $"{electricExpenses[j].BelongDate.Month}月";
                    SeriesPoint point = new SeriesPoint();
                    point.Argument = month;

                    if (type == 0)
                    {
                        point.Values = new double[] { Convert.ToDouble(electricExpenses[j].TotalQuantity) };
                        unit = "度";
                    }
                    else if (type == 1)
                    {
                        point.Values = new double[] { Convert.ToDouble(electricExpenses[j].TotalAmount) };
                        unit = "元";
                    }
                    points.Add(point);
                }

                this.energyChart.AddSeries(title, points, unit, showLabel);
            }
        }

        /// <summary>
        /// 载入用水支出数据
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="years">年度列表</param>
        /// <param name="type">类型</param>
        /// <param name="showLabel">是否显示标签</param>
        private void LoadWaterData(ExpenseAccount account, int[] years, int type, bool showLabel)
        {
            for (int i = 0; i < years.Length; i++)
            {
                int year = years[i];
                string title = $"{year}年";

                var waterExpenses = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(account.Id, year).ToList();

                List<SeriesPoint> points = new List<SeriesPoint>();
                string unit = "";

                for (int j = 0; j < waterExpenses.Count; j++)
                {
                    string month = $"{waterExpenses[j].BelongDate.Month}月";
                    SeriesPoint point = new SeriesPoint();
                    point.Argument = month;

                    if (type == 0)
                    {
                        point.Values = new double[] { Convert.ToDouble(waterExpenses[j].TotalQuantity) };
                        unit = "吨";
                    }
                    else if (type == 1)
                    {
                        point.Values = new double[] { Convert.ToDouble(waterExpenses[j].TotalAmount) };
                        unit = "元";
                    }
                    points.Add(point);
                }

                this.energyChart.AddSeries(title, points, unit, showLabel);
            }
        }

        /// <summary>
        /// 载入用气支出数据
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="years">年度列表</param>
        /// <param name="type">类型</param>
        /// <param name="showLabel">是否显示标签</param>
        private void LoadGasData(ExpenseAccount account, int[] years, int type, bool showLabel)
        {
            for (int i = 0; i < years.Length; i++)
            {
                int year = years[i];
                string title = $"{year}年";

                var gasExpenses = BusinessFactory<GasExpenseBusiness>.Instance.FindYearByAccount(account.Id, year).ToList();

                List<SeriesPoint> points = new List<SeriesPoint>();
                string unit = "";

                for (int j = 0; j < gasExpenses.Count; j++)
                {
                    string month = $"{gasExpenses[j].BelongDate.Month}月";
                    SeriesPoint point = new SeriesPoint();
                    point.Argument = month;

                    if (type == 0)
                    {
                        point.Values = new double[] { Convert.ToDouble(gasExpenses[j].TotalQuantity) };
                        unit = "立方";
                    }
                    else if (type == 1)
                    {
                        point.Values = new double[] { Convert.ToDouble(gasExpenses[j].TotalAmount) };
                        unit = "元";
                    }
                    points.Add(point);
                }

                this.energyChart.AddSeries(title, points, unit, showLabel);
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置关联支出账户
        /// </summary>
        /// <param name="account">支出账户</param>
        /// <param name="energyType">能源支出类型</param>
        public void SetAccount(ExpenseAccount account, EnergyExpenseType energyType)
        {
            this.currentAccount = account;
            this.energyType = energyType;
            this.nowYear = DateTime.Now.Year;

            InitControls();
        }

        /// <summary>
        /// 清空显示
        /// </summary>
        public void Clear()
        {
            this.ccbYears.EditValue = "";
            this.energyChart.Clear();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 年度选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ccbYears_EditValueChanged(object sender, EventArgs e)
        {
            this.energyChart.Clear();

            var years = GetSelectYears();
            if (years == null)
                return;

            if (this.energyType == EnergyExpenseType.Electric)
            {
                LoadElectricData(this.currentAccount, years, this.cmbDataType.SelectedIndex, this.chkShowLabel.Checked);
            }
            else if (this.energyType == EnergyExpenseType.Water)
            {
                LoadWaterData(this.currentAccount, years, this.cmbDataType.SelectedIndex, this.chkShowLabel.Checked);
            }
            else if (this.energyType == EnergyExpenseType.Gas)
            {
                LoadGasData(this.currentAccount, years, this.cmbDataType.SelectedIndex, this.chkShowLabel.Checked);
            }
        }

        /// <summary>
        /// 显示类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.energyChart.Clear();

            var years = GetSelectYears();
            if (years == null)
                return;

            if (this.energyType == EnergyExpenseType.Electric)
            {
                LoadElectricData(this.currentAccount, years, this.cmbDataType.SelectedIndex, this.chkShowLabel.Checked);
            }
            else if (this.energyType == EnergyExpenseType.Water)
            {
                LoadWaterData(this.currentAccount, years, this.cmbDataType.SelectedIndex, this.chkShowLabel.Checked);
            }
            else if (this.energyType == EnergyExpenseType.Gas)
            {
                LoadGasData(this.currentAccount, years, this.cmbDataType.SelectedIndex, this.chkShowLabel.Checked);
            }
        }

        /// <summary>
        /// 是否显示数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShowLabel_CheckedChanged(object sender, EventArgs e)
        {
            this.energyChart.SetLabelVisible(this.chkShowLabel.Checked);
        }
        #endregion //Event
    }
}
