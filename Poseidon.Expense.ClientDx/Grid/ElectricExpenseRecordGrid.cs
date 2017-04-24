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
    using Poseidon.Winform.Base;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Winform.Core.Utility;

    /// <summary>
    /// 电费支出记录表格控件
    /// </summary>
    public partial class ElectricExpenseRecordGrid : WinEntityGrid<ElectricExpenseRecord>
    {
        #region Constructor
        public ElectricExpenseRecordGrid()
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
            ControlUtil.BindDictToComboBox(this.repoCmbFeeType, typeof(ElectricExpenseRecord), "FeeType");
        }
        #endregion //Method
    }
}
