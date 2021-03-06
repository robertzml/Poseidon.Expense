﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Expense.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 电表类
    /// </summary>
    public class ElectricMeter : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 段户号
        /// </summary>
        [Display(Name = "段户号")]
        public string SectionNumber { get; set; }

        /// <summary>
        /// 总户号
        /// </summary>
        [Display(Name = "总户号")]
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

        /// <summary>
        /// 倍率
        /// </summary>
        [Display(Name = "倍率")]
        public decimal Multiple { get; set; }
        #endregion //Property
    }
}
