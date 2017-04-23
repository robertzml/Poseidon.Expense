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

    /// <summary>
    /// 水表表格控件
    /// </summary>
    public partial class WaterMeterGrid : WinEntityGrid<WaterMeter>
    {
        #region Constructor
        public WaterMeterGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor
    }
}
