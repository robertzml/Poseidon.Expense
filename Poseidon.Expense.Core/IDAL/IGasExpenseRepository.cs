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
    /// 气费支出票据数据访问接口
    /// </summary>
    internal interface IGasExpenseRepository : IBaseDAL<GasExpense>
    {
    }
}
