using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Expense.Core.Utility
{
    /// <summary>
    /// 能源支出类型
    /// </summary>
    public enum ExpenseType
    {
        /// <summary>
        /// 电
        /// </summary>
        [Display(Name = "电")]
        Electric = 1,

        /// <summary>
        /// 水
        /// </summary>
        [Display(Name = "水")]
        Water = 2,

        /// <summary>
        /// 天然气
        /// </summary>
        [Display(Name = "天然气")]
        Gas = 3,

        /// <summary>
        /// 热水
        /// </summary>
        [Display(Name = "热水")]
        HotWater = 4
    }
}
