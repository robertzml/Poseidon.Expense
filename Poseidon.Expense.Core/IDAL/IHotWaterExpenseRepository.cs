using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Expense.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Expense.Core.DL;

    /// <summary>
    /// 热水费用支出数据访问接口
    /// </summary>
    internal interface IHotWaterExpenseRepository : IBaseDAL<HotWaterExpense>
    {
        /// <summary>
        /// 按账户查询年度支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        IEnumerable<HotWaterExpense> FindYearByAccount(string accountId, int year);
    }
}
