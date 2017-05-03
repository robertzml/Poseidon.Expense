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

        /// <summary>
        /// 按账户查询年度支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public IEnumerable<GasExpense> FindYearByAccount(string accountId, int year)
        {
            var data = this.baseDal.FindListByField("accountId", accountId);
            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year, 12, 31);

            return data.Where(r => r.BelongDate >= start && r.BelongDate <= end).OrderBy(r => r.BelongDate);
        }



        /// <summary>
        /// 载入最近记录
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        public GasExpense FindLast(string accountId)
        {
            var data = this.baseDal.FindListByField("accountId", accountId).OrderByDescending(r => r.BelongDate);
            if (data.Count() > 0)
                return data.First();
            else
                return null;
        }

        /// <summary>
        /// 添加气费支出
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        public void Create(GasExpense entity, LoginUser user)
        {
            entity.CreateBy = new UpdateStamp
            {
                UserId = user.Id,
                Name = user.Name,
                Time = DateTime.Now
            };
            entity.UpdateBy = new UpdateStamp
            {
                UserId = user.Id,
                Name = user.Name,
                Time = DateTime.Now
            };
            entity.Status = 0;
            base.Create(entity);
        }

        /// <summary>
        /// 编辑气费支出
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        /// <returns></returns>
        public bool Update(GasExpense entity, LoginUser user)
        {
            entity.UpdateBy = new UpdateStamp
            {
                UserId = user.Id,
                Name = user.Name,
                Time = DateTime.Now
            };
            return base.Update(entity);
        }
        #endregion //Method
    }
}
