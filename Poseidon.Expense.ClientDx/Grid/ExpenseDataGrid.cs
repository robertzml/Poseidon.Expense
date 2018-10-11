using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Expense.ClientDx
{
    using Poseidon.Winform.Base;
    using Poseidon.Expense.ClientDx.Model;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 支出数据表格控件
    /// </summary>
    public partial class ExpenseDataGrid : WinEntityGrid<ExpenseDataModel>
    {
        #region Field
        /// <summary>
        /// 是否显示单价列
        /// </summary>
        private bool showUnitPrice = true;

        /// <summary>
        /// 是否显示附加数据
        /// </summary>
        private bool showAdditionData = false;

        /// <summary>
        /// 是否显示名称列
        /// </summary>
        private bool showColName = true;

        /// <summary>
        /// 是否显示归属日期列
        /// </summary>
        private bool showColBelongDate = true;
        #endregion //Field

        #region Constructor
        public ExpenseDataGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 设置能源类型，控制界面显示
        /// </summary>
        /// <param name="energyType">能源类型</param>
        /// <param name="unit">单位</param>
        public void SetEnergyType(EnergyExpenseType energyType, string unit)
        {
            switch (energyType)
            {
                case EnergyExpenseType.Electric:
                    this.colQuantum.Caption = $"用电量({unit})";
                    this.colUnitPrice.Caption = "单价(元/度)";
                    this.colAdditionData.Caption = "功率因数奖(元)";
                    break;
                case EnergyExpenseType.Water:
                    this.colQuantum.Caption = $"用水量({unit})";
                    this.colUnitPrice.Caption = "单价(元/吨)";
                    break;
                case EnergyExpenseType.Gas:
                    this.colQuantum.Caption = $"用气量({unit})";
                    this.colUnitPrice.Caption = "单价(元/立方)";
                    break;
                case EnergyExpenseType.HotWater:
                    this.colQuantum.Caption = $"热水量({unit})";
                    this.colUnitPrice.Caption = "单价(元/吨)";
                    break;
            }
        }

        /// <summary>
        /// 显示附加数据列
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="visible">是否显示</param>
        public void ShowAddition(string caption, bool visible = true)
        {
            this.colAdditionData.Caption = caption;
            this.colAdditionData.Visible = visible;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 是否显示单价列
        /// </summary>
        [Description("是否显示单价列"), Category("界面"), Browsable(true)]
        public bool ShowUnitPrice
        {
            get
            {
                return this.showUnitPrice;
            }
            set
            {
                this.showUnitPrice = value;
                this.colUnitPrice.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示附加数据
        /// </summary>
        [Description("是否显示附加数据"), Category("界面"), Browsable(true)]
        public bool ShowAddtionData
        {
            get
            {
                return this.showAdditionData;
            }
            set
            {
                this.showAdditionData = value;
                this.colAdditionData.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示名称列
        /// </summary>
        [Description("是否显示名称列"), Category("界面"), Browsable(true)]
        public bool ShowColName
        {
            get
            {
                return showColName;
            }

            set
            {
                showColName = value;
                this.colName.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示归属日期列
        /// </summary>
        [Description("是否显示归属日期列"), Category("界面"), Browsable(true)]
        public bool ShowColBelongDate
        {
            get
            {
                return showColBelongDate;
            }

            set
            {
                showColBelongDate = value;
                this.colBelongDate.Visible = value;
            }
        }
        #endregion //Property
    }
}
