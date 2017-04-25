using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Expense.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.IDAL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 气费支出业务类
    /// </summary>
    public class GasExpenseBusiness : AbstractBusiness<GasExpense>
    {
        #region Constructor
        /// <summary>
        /// 气费支出业务类
        /// </summary>
        public GasExpenseBusiness()
        {
            this.baseDal = RepositoryFactory<IGasExpenseRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按账户查询支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        public IEnumerable<GasExpense> FindByAccount(string accountId)
        {
            return this.baseDal.FindListByField("accountId", accountId);
        }
        #endregion //Method
    }
}
