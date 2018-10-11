using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Expense.Core.Utility
{
    /// <summary>
    /// 支出数据接口
    /// </summary>
    public interface IExpenseData
    {
        /// <summary>
        /// 获取账户年度数据
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        IEnumerable<ExpenseDataModel> GetExpenseDataModel(string accountId, int year);
    }
}
