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
    /// 热水费用支出业务类
    /// </summary>
    public class HotWaterExpenseBusiness : AbstractBusiness<HotWaterExpense>
    {
        #region Constructor
        /// <summary>
        /// 热水费用支出业务类
        /// </summary>
        public HotWaterExpenseBusiness()
        {
            this.baseDal = RepositoryFactory<IHotWaterExpenseRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按账户查询支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <returns></returns>
        public IEnumerable<HotWaterExpense> FindByAccount(string accountId)
        {
            return this.baseDal.FindListByField("accountId", accountId);
        }

        /// <summary>
        /// 按账户查询年度支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public IEnumerable<HotWaterExpense> FindYearByAccount(string accountId, int year)
        {
            var dal = this.baseDal as IHotWaterExpenseRepository;
            return dal.FindYearByAccount(accountId, year);
        }

        /// <summary>
        /// 获取账户年度数据
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public IEnumerable<ExpenseDataModel> GetExpenseDataModel(string accountId, int year)
        {
            var dal = this.baseDal as IHotWaterExpenseRepository;
            var data = dal.FindYearByAccount(accountId, year);

            List<ExpenseDataModel> model = new List<ExpenseDataModel>();
            foreach (var item in data)
            {
                ExpenseDataModel m = new ExpenseDataModel();
                m.Name = item.Period;
                m.BelongDate = item.BelongDate;
                m.Quantum = item.TotalQuantity;
                m.Amount = item.TotalAmount;
                m.UnitPrice = item.UnitPrice;

                model.Add(m);
            }

            return model;
        }

        /// <summary>
        /// 添加热水费用支出
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        public void Create(HotWaterExpense entity, LoginUser user)
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
        /// 编辑热水费用支出
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="user">操作用户</param>
        /// <returns></returns>
        public bool Update(HotWaterExpense entity, LoginUser user)
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
