using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Expense.Core.Utility
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 支出数据模型
    /// </summary>
    public class ExpenseDataModel : BaseEntity
    {
        #region Property
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 归属日期
        /// </summary>
        [Display(Name = "归属日期")]
        public DateTime BelongDate { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [Display(Name = "用量")]
        public decimal Quantum { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Display(Name = "单价")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Display(Name = "金额")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        [Display(Name = "附加数据")]
        public decimal AdditionData { get; set; }
        #endregion //Property
    }
}
