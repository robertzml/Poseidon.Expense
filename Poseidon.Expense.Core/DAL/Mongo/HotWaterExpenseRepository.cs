﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Expense.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Poseidon.Data;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.IDAL;

    /// <summary>
    /// 热水费支出数据访问类
    /// </summary>
    internal class HotWaterExpenseRepository : AbstractDALMongo<HotWaterExpense>, IHotWaterExpenseRepository
    {
        #region Constructor
        /// <summary>
        /// 热水费支出数据访问类
        /// </summary>
        public HotWaterExpenseRepository()
        {
            base.Init("expense_hotWaterExpense");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override HotWaterExpense DocToEntity(BsonDocument doc)
        {
            HotWaterExpense entity = new HotWaterExpense();
            entity.Id = doc["_id"].ToString();
            entity.AccountId = doc["accountId"].ToString();
            entity.FeeType = doc["feeType"].ToInt32();
            entity.Period = doc["period"].ToString();
            entity.BelongDate = doc["belongDate"].ToLocalTime();
            entity.TotalQuantity = doc["totalQuantity"].ToDecimal();
            entity.UnitPrice = doc["unitPrice"].ToDecimal();
            entity.TotalAmount = doc["totalAmount"].ToDecimal();

            var createBy = doc["createBy"].ToBsonDocument();
            entity.CreateBy = new UpdateStamp
            {
                UserId = createBy["userId"].ToString(),
                Name = createBy["name"].ToString(),
                Time = createBy["time"].ToLocalTime()
            };

            var updateBy = doc["updateBy"].ToBsonDocument();
            entity.UpdateBy = new UpdateStamp
            {
                UserId = updateBy["userId"].ToString(),
                Name = updateBy["name"].ToString(),
                Time = updateBy["time"].ToLocalTime()
            };

            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(HotWaterExpense entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "accountId", entity.AccountId },
                { "feeType", entity.FeeType },
                { "period", entity.Period },
                { "belongDate", entity.BelongDate },
                { "totalQuantity", entity.TotalQuantity },
                { "unitPrice", entity.UnitPrice },
                { "totalAmount", entity.TotalAmount },
                { "createBy", new BsonDocument {
                    { "userId", entity.CreateBy.UserId },
                    { "name", entity.CreateBy.Name },
                    { "time", entity.CreateBy.Time }
                }},
                { "updateBy", new BsonDocument {
                    { "userId", entity.UpdateBy.UserId },
                    { "name", entity.UpdateBy.Name },
                    { "time", entity.UpdateBy.Time }
                }},
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            return doc;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 按账户查询年度支出
        /// </summary>
        /// <param name="accountId">账户ID</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public IEnumerable<HotWaterExpense> FindYearByAccount(string accountId, int year)
        {
            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year, 12, 31);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("accountId", accountId) & builder.Gte("belongDate", start) & builder.Lte("belongDate", end);

            return base.FindList(filter);
        }
        #endregion //Method
    }
}
