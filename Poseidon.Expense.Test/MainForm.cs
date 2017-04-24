using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Expense.Test
{
    using Poseidon.Winform.Base;
    using Poseidon.Expense.ClientDx;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuExpenseAccount_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmExpenseAccount));
        }

        private void menuExpenseReceipt_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmExpenseReceipt));
        }

        private void menuExpenseOverview_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmExpenseOverview));
        }
    }
}
