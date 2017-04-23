﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Expense.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Expense.Core.DL;

    /// <summary>
    /// 水费支出票据数据访问接口
    /// </summary>
    internal interface IWaterExpenseRepository : IBaseDAL<WaterExpense>
    {
    }
}