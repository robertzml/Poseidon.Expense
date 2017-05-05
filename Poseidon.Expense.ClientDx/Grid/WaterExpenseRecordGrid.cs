using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Expense.ClientDx
{
    using Poseidon.Winform.Base;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Winform.Core.Utility;

    /// <summary>
    /// 水费支出记录表格控件
    /// </summary>
    public partial class WaterExpenseRecordGrid : WinEntityGrid<WaterExpenseRecord>
    {
        #region Field
        /// <summary>
        /// 是否显示归属日期
        /// </summary>
        private bool showBelongDate = false;
        #endregion //Field

        #region Constructor
        public WaterExpenseRecordGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化组件
        /// </summary>
        public void Init()
        {
            ControlUtil.BindDictToComboBox(this.repoCmbFeeType, typeof(WaterExpenseRecord), "FeeType");
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaterExpenseRecordGrid_Load(object sender, EventArgs e)
        {
            this.colBelongDate.Visible = this.showBelongDate;
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsEntity.Count)
                return;

            var record = this.bsEntity[rowIndex] as WaterExpenseRecord;
            if (this.showBelongDate && e.Column.FieldName == "colBelongDate" && e.IsGetData)
            {
                if (string.IsNullOrEmpty(record.Id))
                {
                    e.Value = "";
                    return;
                }
                else
                {
                    e.Value = Convert.ToDateTime(record.Id);
                }
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 是否显示归属日期
        /// </summary>
        [Description("是否显示归属日期"), Category("界面"), Browsable(true)]
        public bool ShowBelongDate
        {
            get
            {
                return showBelongDate;
            }

            set
            {
                showBelongDate = value;
            }
        }
        #endregion //Property
    }
}
