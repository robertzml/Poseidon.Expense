﻿using System;
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
    /// 电费支出单据业务类
    /// </summary>
    public class ElectricExpenseBusiness : AbstractBusiness<ElectricExpense>
    {
        #region Constructor
        /// <summary>
        /// 电费支出单据业务类
        /// </summary>
        public ElectricExpenseBusiness()
        {
            this.baseDal = RepositoryFactory<IElectricExpenseRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按账户查询支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        public IEnumerable<ElectricExpense> FindByAccount(string accountId)
        {
            return this.baseDal.FindListByField("accountId", accountId);
        }

        /// <summary>
        /// 载入最近记录
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        public ElectricExpense FindLast(string accountId)
        {
            var data = this.baseDal.FindListByField("accountId", accountId).OrderByDescending(r => r.BelongDate);
            if (data.Count() > 0)
                return data.First();
            else
                return null;
        }

        /// <summary>
        /// 按账户查询年度支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public IEnumerable<ElectricExpense> FindYearByAccount(string accountId, int year)
        {
            var data = this.baseDal.FindListByField("accountId", accountId);
            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year, 12, 31);

            return data.Where(r => r.BelongDate >= start && r.BelongDate <= end).OrderBy(r => r.BelongDate);
        }

        /// <summary>
        /// 添加电费支出
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        public void Create(ElectricExpense entity, LoginUser user)
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
        /// 编辑电费支出
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        /// <returns></returns>
        public bool Update(ElectricExpense entity, LoginUser user)
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