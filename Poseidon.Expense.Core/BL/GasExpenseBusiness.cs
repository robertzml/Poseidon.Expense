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
    /// 气费支出业务类
    /// </summary>
    public class GasExpenseBusiness : AbstractBusiness<GasExpense>, IExpenseData
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
            var dal = this.baseDal as IGasExpenseRepository;
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
            var dal = this.baseDal as IGasExpenseRepository;
            var data = dal.FindYearByAccount(accountId, year);

            List<ExpenseDataModel> model = new List<ExpenseDataModel>();
            foreach (var item in data)
            {
                ExpenseDataModel m = new ExpenseDataModel();
                m.Name = "";
                m.BelongDate = item.BelongDate;
                m.Quantum = item.TotalQuantity;
                m.Amount = item.TotalAmount;
                m.UnitPrice = m.Quantum == 0 ? 0 : Math.Round(m.Amount / m.Quantum, 2);

                model.Add(m);
            }

            return model;
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
        public void Create(GasExpense entity, ILoginUser user)
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
        public (bool success, string errorMessage) Update(GasExpense entity, ILoginUser user)
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
