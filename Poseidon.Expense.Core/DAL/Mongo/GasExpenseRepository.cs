using System;
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
    /// 气费支出数据访问类
    /// </summary>
    internal class GasExpenseRepository : AbstractDALMongo<GasExpense>, IGasExpenseRepository
    {
        #region Constructor
        /// <summary>
        /// 气费支出数据访问类
        /// </summary>
        public GasExpenseRepository()
        {
            base.Init("expense_gasExpense");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override GasExpense DocToEntity(BsonDocument doc)
        {
            GasExpense entity = new GasExpense();
            entity.Id = doc["_id"].ToString();
            entity.AccountId = doc["accountId"].ToString();
            entity.FeeType = doc["feeType"].ToInt32();
            entity.BelongDate = doc["belongDate"].ToLocalTime();
            entity.TicketDate = doc["ticketDate"].ToLocalTime();
            entity.TotalQuantity = doc["totalQuantity"].ToDecimal();
            entity.TotalAmount = doc["totalAmount"].ToDecimal();

            entity.Records = new List<GasExpenseRecord>();
            if (doc.Contains("records"))
            {
                BsonArray array = doc["records"].AsBsonArray;
                foreach (BsonDocument item in array)
                {
                    GasExpenseRecord record = new GasExpenseRecord();
                    record.MeterNumber = item["meterNumber"].ToString();
                    record.MeterName = item["meterName"].ToString();
                    record.FeeType = item["feeType"].ToInt32();
                    record.Previous = item["previous"].ToDecimal();
                    record.Current = item["current"].ToDecimal();
                    record.Quantity = item["quantity"].ToDecimal();
                    record.UnitPrice = item["unitPrice"].ToDecimal();
                    record.Amount = item["amount"].ToDecimal();
                    record.Remark = item["remark"].ToString();

                    entity.Records.Add(record);
                }
            }

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
        protected override BsonDocument EntityToDoc(GasExpense entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "accountId", entity.AccountId },
                { "feeType", entity.FeeType },
                { "belongDate", entity.BelongDate },
                { "ticketDate", entity.TicketDate },
                { "totalQuantity", entity.TotalQuantity },
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

            if (entity.Records != null && entity.Records.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.Records)
                {
                    BsonDocument record = new BsonDocument
                    {
                        { "meterNumber", item.MeterNumber },
                        { "meterName", item.MeterName },
                        { "feeType", item.FeeType },
                        { "previous", item.Previous },
                        { "current", item.Current },
                        { "quantity", item.Quantity },
                        { "unitPrice", item.UnitPrice },
                        { "amount", item.Amount },
                        { "remark", item.Remark }
                    };

                    array.Add(record);
                }

                doc.Add("records", array);
            }

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
        public IEnumerable<GasExpense> FindYearByAccount(string accountId, int year)
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
