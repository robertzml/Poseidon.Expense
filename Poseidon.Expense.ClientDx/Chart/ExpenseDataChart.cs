﻿using System;
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
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 能源支出图表控件
    /// </summary>
    public partial class ExpenseDataChart : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// X轴只显示月份
        /// </summary>
        private bool showMonthTick = false;
        #endregion //Field

        #region Constructor
        public ExpenseDataChart()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 设置图表标题
        /// </summary>
        /// <param name="text"></param>
        public void SetChartTitle(string text)
        {
            this.chartMain.Titles[0].Text = text;
        }

        /// <summary>
        /// 设置系列名称
        /// </summary>
        /// <param name="index">序号</param>
        /// <param name="text">名称</param>
        public void SetSeriesName(int index, string text)
        {
            this.chartMain.Series[index].Name = text;
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="data"></param>
        public void SetDataSource(List<ExpenseDataModel> data)
        {
            List<ExpenseDataModel> format = new List<ExpenseDataModel>();

            if (data.Count == 0)
            {
                this.bsExpense.DataSource = null;
                return;
            }

            format.AddRange(data);
            var last = data.Max(r => r.BelongDate);
            for (int i = last.Month + 1; i <= 12; i++)
            {
                format.Add(new ExpenseDataModel
                {
                    BelongDate = new DateTime(last.Year, i, 1),
                    Amount = 0,
                    Quantum = 0
                });
            }

            this.bsExpense.DataSource = format.OrderBy(r => r.BelongDate).ToList();
        }

        /// <summary>
        /// 清空显示
        /// </summary>
        public void Clear()
        {
            this.bsExpense.DataSource = null;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPrint_Click(object sender, EventArgs e)
        {
            this.chartMain.ShowRibbonPrintPreview();
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<ExpenseDataModel> DataSource
        {
            get
            {
                return this.bsExpense.DataSource as List<ExpenseDataModel>;
            }
            set
            {
                this.bsExpense.DataSource = value;
            }
        }

        /// <summary>
        /// X轴显示月份
        /// </summary>
        [Description("X轴显示月份"), Category("界面"), Browsable(true)]
        public bool ShowMonthTick
        {
            get
            {
                return this.showMonthTick;
            }
            set
            {
                this.showMonthTick = value;
                if (value)
                {
                    XYDiagram diagram = this.chartMain.Diagram as XYDiagram;
                    diagram.AxisX.Label.TextPattern = "{A:M月}";
                }
                else
                {
                    XYDiagram diagram = this.chartMain.Diagram as XYDiagram;
                    diagram.AxisX.Label.TextPattern = "{A:yyyy年M月}";
                }
            }
        }
        #endregion //Property
    }
}