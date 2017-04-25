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
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;

    /// <summary>
    /// 支出账户管理窗体
    /// </summary>
    public partial class FrmExpenseAccount : BaseMdiForm
    {
        #region Field
        /// <summary>
        /// 当前选择账户
        /// </summary>
        private ExpenseAccount currentAccount;
        #endregion //Field

        #region Constructor
        public FrmExpenseAccount()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            LoadAccount();
            base.InitForm();
        }

        /// <summary>
        /// 载入账户
        /// </summary>
        private void LoadAccount()
        {
            this.bsAccount.DataSource = BusinessFactory<ExpenseAccountBusiness>.Instance.FindAll().ToList();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 账户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbAccount.SelectedItem == null)
                return;

            this.currentAccount = this.lbAccount.SelectedItem as ExpenseAccount;

            this.txtName.Text = this.currentAccount.Name;
            this.txtShortName.Text = this.currentAccount.ShortName;
            this.txtRemark.Text = this.currentAccount.Remark;

            this.electricGrid.DataSource = this.currentAccount.ElectricMeters;
            this.waterGrid.DataSource = this.currentAccount.WaterMeters;
            this.gasGrid.DataSource = this.currentAccount.GasMeters;
        }

        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmExpenseAccountAdd));
            LoadAccount();
        }

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.currentAccount == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmExpenseAccountEdit), new object[] { this.currentAccount.Id });
            LoadAccount();
        }

        /// <summary>
        /// 设置电表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetEletric_Click(object sender, EventArgs e)
        {
            if (this.currentAccount == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmElectricMeterSet), new object[] { this.currentAccount.Id });
            LoadAccount();
        }

        /// <summary>
        /// 设置水表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetWater_Click(object sender, EventArgs e)
        {
            if (this.currentAccount == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmWaterMeterSet), new object[] { this.currentAccount.Id });
            LoadAccount();
        }

        /// <summary>
        /// 设置气表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetGas_Click(object sender, EventArgs e)
        {
            if (this.currentAccount == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmGasMeterSet), new object[] { this.currentAccount.Id });
            LoadAccount();
        }
        #endregion //Event
    }
}
