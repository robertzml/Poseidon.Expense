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
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Core.Utility;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Winform.Base;
    using Poseidon.Winform.Core.Utility;

    /// <summary>
    /// 电费支出单据管理控件
    /// </summary>
    public partial class ElectricReceipt : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 当前关联账户
        /// </summary>
        private ExpenseAccount currentAccount;

        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable;
        #endregion //Field

        #region Constructor
        public ElectricReceipt()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入票据列表
        /// </summary>
        private void LoadReceipts()
        {
            if (this.currentAccount == null)
                return;

            var receipts = BusinessFactory<ElectricExpenseBusiness>.Instance.FindByAccount(this.currentAccount.Id).OrderByDescending(r => r.BelongDate);
            this.bsElectricExpense.DataSource = receipts;
        }

        /// <summary>
        /// 显示电费支出信息
        /// </summary>
        /// <param name="entity">电费支出</param>
        private void ShowElectricExpense(ElectricExpense entity)
        {
            this.txtBelongDate.Text = entity.BelongDate.ToString("yyyy年MM月");
            this.txtTicketDate.Text = entity.TicketDate.ToDateString();
            this.txtFeeType.Text = DictUtility.GetDictValue(entity, "FeeType", entity.FeeType);
            this.txtTotalQuantity.Text = entity.TotalQuantity.ToString();
            this.txtTotalAmount.Text = entity.TotalAmount.ToString();
            this.txtTotalPrize.Text = entity.TotalPrize.ToString();
            this.txtRemark.Text = entity.Remark;
            this.txtCreateUser.Text = entity.CreateBy.Name;
            this.txtCreateTime.Text = entity.CreateBy.Time.ToDateTimeString();
            this.txtEditUser.Text = entity.UpdateBy.Name;
            this.txtEditTime.Text = entity.UpdateBy.Time.ToDateTimeString();

            this.electricExpRecGrid.DataSource = entity.Records;
            this.attachmentGrid.Init(entity.AttachmentIds);
        }

        /// <summary>
        /// 清空显示
        /// </summary>
        private void Clear()
        {
            this.txtBelongDate.Text = "";
            this.txtTicketDate.Text = "";
            this.txtFeeType.Text = "";
            this.txtTotalQuantity.Text = "";
            this.txtTotalAmount.Text = "";
            this.txtTotalPrize.Text = "";
            this.txtRemark.Text = "";
            this.txtCreateUser.Text = "";
            this.txtCreateTime.Text = "";
            this.txtEditUser.Text = "";
            this.txtEditTime.Text = "";

            this.electricExpRecGrid.Clear();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置关联账户
        /// </summary>
        /// <param name="account"></param>
        public void SetAccount(ExpenseAccount account)
        {
            this.currentAccount = account;
            this.electricExpRecGrid.Init();

            LoadReceipts();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElectricExpenseReceipt_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.lbElectricReceipt.DrawItem += EventUtil.lbMonth_DrawItem;
            }

            if (!this.editable)
                this.lcGroupAction.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        /// <summary>
        /// 选择电费支出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbElectricReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbElectricReceipt.SelectedValue == null)
            {
                Clear();
                return;
            }

            ShowElectricExpense(this.lbElectricReceipt.SelectedItem as ElectricExpense);
        }

        /// <summary>
        /// 登记单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.currentAccount == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmElectricExpenseAdd), new object[] { this.currentAccount.Id });
            LoadReceipts();
        }

        /// <summary>
        /// 编辑单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.currentAccount == null || this.lbElectricReceipt.SelectedValue == null)
                return;

            var expense = this.lbElectricReceipt.SelectedItem as ElectricExpense;
            ChildFormManage.ShowDialogForm(typeof(FrmElectricExpenseEdit), new object[] { expense.Id, this.currentAccount.Id });
            LoadReceipts();
        }

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentAccount == null || this.lbElectricReceipt.SelectedValue == null)
                return;

            var expense = this.lbElectricReceipt.SelectedItem as ElectricExpense;

            if (MessageUtil.ConfirmYesNo("是否确认删除选中电费支出") == DialogResult.Yes)
            {
                try
                {
                    var result = BusinessFactory<ElectricExpenseBusiness>.Instance.Delete(expense);

                    if (result.success)
                    {
                        LoadReceipts();
                        MessageUtil.ShowInfo("删除成功");
                    }
                    else
                    {
                        MessageUtil.ShowClaim("删除失败: " + result.errorMessage);
                    }
                }
                catch (PoseidonException pe)
                {
                    MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
                }
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 是否能编辑
        /// </summary>
        [Description("是否能编辑")]
        public bool Editable
        {
            get
            {
                return this.editable;
            }
            set
            {
                this.editable = value;
            }
        }
        #endregion //Property        
    }
}
