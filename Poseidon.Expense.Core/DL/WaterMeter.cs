﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Expense.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 水表类
    /// </summary>
    public class WaterMeter : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 客户编号
        /// </summary>
        [Display(Name = "客户编号")]
        public string Number { get; set; }

        /// <summary>
        /// 户名
        /// </summary>
        [Display(Name = "户名")]
        public string AccountName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Address { get; set; }
        #endregion //Property
    }
}
