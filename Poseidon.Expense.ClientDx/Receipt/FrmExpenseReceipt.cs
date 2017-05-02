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
    using Poseidon.Winform.Base;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 支出单据窗体
    /// </summary>
    public partial class FrmExpenseReceipt : BaseMdiForm
    {
        #region Field
        /// <summary>
        /// 当前选择账户
        /// </summary>
        private ExpenseAccount currentAccount;
        #endregion //Field

        #region Constructor
        public FrmExpenseReceipt()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.groupTree.SetGroupCode(ExpenseConstant.ExpenseAccountGroupCode);
            base.InitForm();
        }

        /// <summary>
        /// 初始化账户信息
        /// </summary>
        private void InitAccountInfo()
        {
            this.ctrAccountInfo.SetAccount(this.currentAccount);

            if (this.currentAccount.EnergyType.Contains(1))
            {
                this.tabPageElectric.PageVisible = true;
                LoadElectric();
            }
            else
                this.tabPageElectric.PageVisible = false;

            if (this.currentAccount.EnergyType.Contains(2))
            {
                this.tabPageWater.PageVisible = true;
                LoadWater();
            }
            else
                this.tabPageWater.PageVisible = false;

            if (this.currentAccount.EnergyType.Contains(3))
            {
                this.tabPageGas.PageVisible = true;
                LoadGas();
            }
            else
                this.tabPageGas.PageVisible = false;

            if (this.currentAccount.EnergyType.Contains(4))
            {
                this.tabPageHotWater.PageVisible = true;
                LoadHotWater();
            }
            else
                this.tabPageHotWater.PageVisible = false;
        }

        /// <summary>
        /// 载入电费相关数据
        /// </summary>
        private void LoadElectric()
        {
            this.electricReceipt.SetAccount(this.currentAccount);
        }

        /// <summary>
        /// 载入水费相关数据
        /// </summary>
        private void LoadWater()
        {
            this.waterReceipt.SetAccount(this.currentAccount);
        }

        /// <summary>
        /// 载入气费相关数据
        /// </summary>
        private void LoadGas()
        {
            this.gasReceipt.SetAccount(this.currentAccount);
        }

        /// <summary>
        /// 载入热水相关数据
        /// </summary>
        private void LoadHotWater()
        {
            this.hotWaterReceipt.SetAccount(this.currentAccount);
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 账户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupTree_EntitySelected(object sender, EventArgs e)
        {
            string id = this.groupTree.GetCurrentSelectId();
            if (id == null)
                this.currentAccount = null;
            else
            {
                this.currentAccount = BusinessFactory<ExpenseAccountBusiness>.Instance.FindById(id);
                InitAccountInfo();
            }
        }
        #endregion //Event
    }
}
