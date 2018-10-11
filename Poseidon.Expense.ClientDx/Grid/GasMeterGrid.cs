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
    /// 气表表格控件
    /// </summary>
    public partial class GasMeterGrid : WinEntityGrid<GasMeter>
    {
        #region Constructor
        public GasMeterGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor
    }
}
