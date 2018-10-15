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
    using Poseidon.Winform.Base;
    using Poseidon.Winform.Core.Utility;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;

    /// <summary>
    /// 编辑热水支出窗体
    /// </summary>
    public partial class FrmHotWaterExpenseEdit : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 当前关联支出
        /// </summary>
        private HotWaterExpense currentExpense;

        /// <summary>
        /// 当前关联账户
        /// </summary>
        private ExpenseAccount currentAccount;
        #endregion //Field

        #region Constructor
        public FrmHotWaterExpenseEdit(string id, string accountId)
        {
            InitializeComponent();
            InitData(id, accountId);
        }
        #endregion //Constructor

        #region Function
        private void InitData(string id, string accountId)
        {
            this.currentExpense = BusinessFactory<HotWaterExpenseBusiness>.Instance.FindById(id);
            this.currentAccount = BusinessFactory<ExpenseAccountBusiness>.Instance.FindById(accountId);
        }

        protected override void InitForm()
        {
            this.txtAccountName.Text = this.currentAccount.Name;

            this.dpBelongDate.DateTime = this.currentExpense.BelongDate;
            this.txtPeriod.Text = this.currentExpense.Period;
            ControlUtil.BindDictToComboBox(this.cmbFeeType, typeof(HotWaterExpense), "FeeType", this.currentExpense.FeeType);
            this.spTotalQuantity.Value = this.currentExpense.TotalQuantity;
            this.spUnitPrice.Value = this.currentExpense.UnitPrice;
            this.spTotalAmount.Value = this.currentExpense.TotalAmount;
            this.txtRemark.Text = this.currentExpense.Remark;

            base.InitForm();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="entity"></param>
        private void SetEntity(HotWaterExpense entity)
        {
            entity.AccountId = this.currentAccount.Id;
            entity.BelongDate = this.dpBelongDate.DateTime.Date;
            entity.Period = this.txtPeriod.Text;
            entity.FeeType = Convert.ToInt32(this.cmbFeeType.EditValue);
            entity.TotalQuantity = this.spTotalQuantity.Value;
            entity.UnitPrice = this.spUnitPrice.Value;
            entity.TotalAmount = this.spTotalAmount.Value;
            entity.Remark = this.txtRemark.Text;
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            if (this.dpBelongDate.EditValue == null)
            {
                errorMessage = "月份不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (string.IsNullOrEmpty(this.txtPeriod.Text))
            {
                errorMessage = "周期不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.cmbFeeType.SelectedIndex == -1)
            {
                errorMessage = "请选择费用类型";
                return new Tuple<bool, string>(false, errorMessage);
            }

            return new Tuple<bool, string>(true, "");
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            try
            {
                HotWaterExpense entity = BusinessFactory<HotWaterExpenseBusiness>.Instance.FindById(this.currentExpense.Id);
                SetEntity(entity);

                var result = BusinessFactory<HotWaterExpenseBusiness>.Instance.Update(entity, this.currentUser);

                if (result.success)
                {
                    MessageUtil.ShowInfo("保存成功");
                    this.Close();
                }
                else
                {
                    MessageUtil.ShowClaim("保存失败: " + result.errorMessage);
                }
            }
            catch (PoseidonException pe)
            {
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
