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
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;

    /// <summary>
    /// 设置电表窗体
    /// </summary>
    public partial class FrmElectricMeterSet : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 当前关联账户
        /// </summary>
        private ExpenseAccount currentAccount;
        #endregion //Field

        #region Constructor
        public FrmElectricMeterSet(string id)
        {
            InitializeComponent();

            InitData(id);
        }
        #endregion //Constructor

        #region Function
        private void InitData(string id)
        {
            this.currentAccount = BusinessFactory<ExpenseAccountBusiness>.Instance.FindById(id);
        }

        protected override void InitForm()
        {
            this.txtName.Text = this.currentAccount.Name;
            this.electricGrid.DataSource = this.currentAccount.ElectricMeters;

            base.InitForm();
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            foreach (var item in this.electricGrid.DataSource)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    errorMessage = "名称不能为空";
                    return new Tuple<bool, string>(false, errorMessage);
                }
            }

            return new Tuple<bool, string>(true, "");
        }

        /// <summary>
        /// 设置对象
        /// </summary>
        /// <param name="entity"></param>
        private void SetEntity(List<ElectricMeter> entity)
        {
            foreach (var item in entity)
            {
                item.AccountName = item.AccountName ?? "";
                item.SectionNumber = item.SectionNumber ?? "";
                item.Number = item.Number ?? "";
                item.Address = item.Address ?? "";
                item.Remark = item.Remark ?? "";
            }
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
            this.electricGrid.CloseEditor();

            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            var data = this.electricGrid.DataSource;
            SetEntity(data);

            try
            {
                BusinessFactory<ExpenseAccountBusiness>.Instance.SetElectricMeters(this.currentAccount.Id, data);

                MessageUtil.ShowInfo("保存成功");
                this.Close();
            }
            catch (PoseidonException pe)
            {
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
