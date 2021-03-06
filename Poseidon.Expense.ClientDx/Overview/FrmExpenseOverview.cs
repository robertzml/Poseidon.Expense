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
    using Poseidon.Winform.Base;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 支出总览窗体
    /// </summary>
    public partial class FrmExpenseOverview : BaseMdiForm
    {
        #region Constructor
        public FrmExpenseOverview()
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
        #endregion //Function

        #region Event
        /// <summary>
        /// 分组选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupTree_GroupSelected(object sender, EventArgs e)
        {
            this.navFrame.SelectedPageIndex = 0;
            var groupId = this.groupTree.GetCurrentSelectId();
            this.groupExpenseMod.SetGroup(groupId);
        }

        /// <summary>
        /// 账户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupTree_EntitySelected(object sender, EventArgs e)
        {
            this.navFrame.SelectedPageIndex = 1;
            var accountId = this.groupTree.GetCurrentSelectId();
            this.accountExpenseMod.SetAccount(accountId);
        }
        #endregion //Event
    }
}
