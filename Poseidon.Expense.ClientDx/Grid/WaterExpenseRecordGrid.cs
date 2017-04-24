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
    using Poseidon.Winform.Core.Utility;
    using Poseidon.Expense.Core.DL;

    /// <summary>
    /// 水费支出记录表格控件
    /// </summary>
    public partial class WaterExpenseRecordGrid : WinEntityGrid<WaterExpenseRecord>
    {
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
    }
}
