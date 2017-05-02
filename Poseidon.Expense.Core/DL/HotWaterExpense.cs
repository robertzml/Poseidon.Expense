using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Expense.Core.DL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.Utility;

    /// <summary>
    /// 热水费用支出类
    /// </summary>
    public class HotWaterExpense : BusinessEntity
    {
        #region Property
        /// <summary>
        /// 账户ID
        /// </summary>
        [Display(Name = "账户ID")]
        public string AccountId { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        [Dict("Energy.Expense.FeeType")]
        [Display(Name = "费用类型")]
        public int FeeType { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        [Display(Name = "周期")]
        public string Period { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        [Display(Name = "月份")]
        public DateTime BelongDate { get; set; }       

        /// <summary>
        /// 用水量
        /// </summary>
        [Display(Name = "用水量")]
        public decimal TotalQuantity { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Display(Name = "金额")]
        public decimal TotalAmount { get; set; }
        #endregion //Property
    }
}
