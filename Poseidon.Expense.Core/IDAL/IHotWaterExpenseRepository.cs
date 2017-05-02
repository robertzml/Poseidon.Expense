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
    }
}
