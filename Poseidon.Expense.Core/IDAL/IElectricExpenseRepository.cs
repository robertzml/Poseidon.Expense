using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Expense.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Expense.Core.DL;

    /// <summary>
    /// 电费支出票据数据访问接口
    /// </summary>
    internal interface IElectricExpenseRepository : IBaseDAL<ElectricExpense>
    {
        /// <summary>
        /// 按账户查询年度支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        IEnumerable<ElectricExpense> FindYearByAccount(string accountId, int year);
    }
}
