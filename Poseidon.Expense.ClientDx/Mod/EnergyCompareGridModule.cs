﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Expense.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Expense.ClientDx.Model;
    using Poseidon.Expense.Core.BL;
    using Poseidon.Expense.Core.DL;
    using Poseidon.Expense.Core.Utility;

    /// <summary>
    /// 能源支出比较表格控件
    /// </summary>
    public partial class EnergyCompareGridModule : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 起始年份
        /// </summary>
        private int startYear = 2011;

        /// <summary>
        /// 关联账户
        /// </summary>
        private ExpenseAccount currentAccount;

        /// <summary>
        /// 能源支出类型
        /// </summary>
        private EnergyExpenseType energyType;

        /// <summary>
        /// 能源比较对象
        /// </summary>
        private List<EnergyCompare> compareData;
        #endregion //Field

        #region Constructor
        public EnergyCompareGridModule()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            int nowYear = DateTime.Now.Year;

            for (int i = nowYear; i >= startYear; i--)
            {
                this.cmbFirst.Properties.Items.Add(i.ToString() + "年");
                this.cmbSecond.Properties.Items.Add(i.ToString() + "年");
            }
        }

        /// <summary>
        /// 初始化比较数据
        /// </summary>
        private void InitCompareData()
        {
            this.compareData = new List<EnergyCompare>();
            for (int i = 1; i <= 12; i++)
            {
                EnergyCompare ec = new EnergyCompare();
                ec.Include = true;
                ec.ItemName = i.ToString() + "月";

                this.compareData.Add(ec);
            }

            this.energyGrid.DataSource = this.compareData;
            this.energyGrid.SetItemNameTitle("月份");
        }

        /// <summary>
        /// 清空列数据
        /// </summary>
        /// <param name="index">列序号</param>
        private void ClearColumnData(int index)
        {
            if (index == 1)
            {
                this.compareData.ForEach(r => r.QuantumFirst = 0);
                this.compareData.ForEach(r => r.AmountFirst = 0);
            }
            else
            {
                this.compareData.ForEach(r => r.QuantumSecond = 0);
                this.compareData.ForEach(r => r.AmountSecond = 0);
            }
        }

        /// <summary>
        /// 设置电能数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="index"></param>
        private void SetElectricCompare(int year, int index)
        {
            var electricExpenses = BusinessFactory<ElectricExpenseBusiness>.Instance.FindYearByAccount(this.currentAccount.Id, year).ToList();

            ClearColumnData(index);
            foreach (var item in electricExpenses)
            {
                var find = this.compareData.Find(r => r.ItemName == string.Format("{0}月", item.BelongDate.Month));

                if (index == 1)
                {
                    find.QuantumFirst = item.TotalQuantity;
                    find.AmountFirst = item.TotalAmount;
                }
                else if (index == 2)
                {
                    find.QuantumSecond = item.TotalQuantity;
                    find.AmountSecond = item.TotalAmount;
                }
            }

            this.energyGrid.SetTitle(index, year.ToString() + "年用电量(度)", year.ToString() + "年用电金额(元)");
            this.energyGrid.UpdateBindingData();
        }

        /// <summary>
        /// 设置用水数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="index"></param>
        private void SetWaterCompare(int year, int index)
        {
            var waterExpenses = BusinessFactory<WaterExpenseBusiness>.Instance.FindYearByAccount(this.currentAccount.Id, year).ToList();

            ClearColumnData(index);
            foreach (var item in waterExpenses)
            {
                var find = this.compareData.Find(r => r.ItemName == string.Format("{0}月", item.BelongDate.Month));

                if (index == 1)
                {
                    find.QuantumFirst = item.TotalQuantity;
                    find.AmountFirst = item.TotalAmount;
                }
                else if (index == 2)
                {
                    find.QuantumSecond = item.TotalQuantity;
                    find.AmountSecond = item.TotalAmount;
                }
            }

            this.energyGrid.SetTitle(index, year.ToString() + "年用水量(吨)", year.ToString() + "年用水金额(元)");
            this.energyGrid.UpdateBindingData();
        }

        /// <summary>
        /// 设置用气数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="index"></param>
        private void SetGasCompare(int year, int index)
        {
            var gasExpenses = BusinessFactory<GasExpenseBusiness>.Instance.FindYearByAccount(this.currentAccount.Id, year).ToList();

            ClearColumnData(index);
            foreach (var item in gasExpenses)
            {
                var find = this.compareData.Find(r => r.ItemName == string.Format("{0}月", item.BelongDate.Month));

                if (index == 1)
                {
                    find.QuantumFirst = item.TotalQuantity;
                    find.AmountFirst = item.TotalAmount;
                }
                else if (index == 2)
                {
                    find.QuantumSecond = item.TotalQuantity;
                    find.AmountSecond = item.TotalAmount;
                }
            }

            this.energyGrid.SetTitle(index, year.ToString() + "年用气量(立方)", year.ToString() + "年用气金额(元)");
            this.energyGrid.UpdateBindingData();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 设置关联支出账户
        /// </summary>
        /// <param name="account">支出账户</param>
        /// <param name="energyType">能源支出类型</param>
        public void SetAccount(ExpenseAccount account, EnergyExpenseType energyType)
        {
            this.currentAccount = account;
            this.energyType = energyType;

            InitControls();
            InitCompareData();
        }

        /// <summary>
        /// 清空显示
        /// </summary>
        public void Clear()
        {
            this.chkAmount.Checked = true;
            this.chkQuantum.Checked = true;
            this.cmbFirst.SelectedIndex = -1;
            this.cmbSecond.SelectedIndex = -1;

            InitCompareData();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 选择数据1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbFirst.SelectedIndex == -1)
                return;

            int year = Convert.ToInt32(this.cmbFirst.SelectedItem.ToString().Substring(0, 4));

            if (this.energyType == EnergyExpenseType.Electric)
                SetElectricCompare(year, 1);
            else if (this.energyType == EnergyExpenseType.Water)
                SetWaterCompare(year, 1);
            else if (this.energyType == EnergyExpenseType.Gas)
                SetGasCompare(year, 1);
        }

        /// <summary>
        /// 选择数据2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSecond.SelectedIndex == -1)
                return;

            int year = Convert.ToInt32(this.cmbSecond.SelectedItem.ToString().Substring(0, 4));

            if (this.energyType == EnergyExpenseType.Electric)
                SetElectricCompare(year, 2);
            else if (this.energyType == EnergyExpenseType.Water)
                SetWaterCompare(year, 2);
            else if (this.energyType == EnergyExpenseType.Gas)
                SetGasCompare(year, 2);
        }

        /// <summary>
        /// 显示用量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkQuantum_CheckedChanged(object sender, EventArgs e)
        {
            this.energyGrid.ShowQuantum(this.chkQuantum.Checked);
        }

        /// <summary>
        /// 显示金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAmount_CheckedChanged(object sender, EventArgs e)
        {
            this.energyGrid.ShowAmount(this.chkAmount.Checked);
        }
        #endregion //Event
    }
}
