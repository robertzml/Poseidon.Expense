﻿namespace Poseidon.Expense.ClientDx
{
    partial class WaterExpenseRecordGrid
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.colMeterNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeeType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoCmbFeeType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colPrevious = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalcAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCmbFeeType)).BeginInit();
            this.SuspendLayout();
            // 
            // bsEntity
            // 
            this.bsEntity.DataSource = typeof(Poseidon.Expense.Core.DL.WaterExpenseRecord);
            // 
            // dgcEntity
            // 
            this.dgcEntity.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCmbFeeType});
            this.dgcEntity.Size = new System.Drawing.Size(668, 378);
            // 
            // dgvEntity
            // 
            this.dgvEntity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMeterNumber,
            this.colMeterName,
            this.colFeeType,
            this.colPrevious,
            this.colCurrent,
            this.colCalQuantity,
            this.colQuantity,
            this.colUnitPrice,
            this.colCalcAmount,
            this.colAmount,
            this.colRemark});
            this.dgvEntity.IndicatorWidth = 40;
            this.dgvEntity.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.Editable = false;
            this.dgvEntity.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvEntity.OptionsView.EnableAppearanceOddRow = true;
            this.dgvEntity.OptionsView.ShowGroupPanel = false;
            // 
            // colMeterNumber
            // 
            this.colMeterNumber.Caption = "水表编号";
            this.colMeterNumber.FieldName = "MeterNumber";
            this.colMeterNumber.Name = "colMeterNumber";
            this.colMeterNumber.Visible = true;
            this.colMeterNumber.VisibleIndex = 0;
            // 
            // colMeterName
            // 
            this.colMeterName.Caption = "水表名称";
            this.colMeterName.FieldName = "MeterName";
            this.colMeterName.Name = "colMeterName";
            this.colMeterName.Visible = true;
            this.colMeterName.VisibleIndex = 1;
            // 
            // colFeeType
            // 
            this.colFeeType.Caption = "费用类型";
            this.colFeeType.ColumnEdit = this.repoCmbFeeType;
            this.colFeeType.FieldName = "FeeType";
            this.colFeeType.Name = "colFeeType";
            this.colFeeType.Visible = true;
            this.colFeeType.VisibleIndex = 2;
            // 
            // repoCmbFeeType
            // 
            this.repoCmbFeeType.AutoHeight = false;
            this.repoCmbFeeType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoCmbFeeType.Name = "repoCmbFeeType";
            // 
            // colPrevious
            // 
            this.colPrevious.Caption = "上期数";
            this.colPrevious.FieldName = "Previous";
            this.colPrevious.Name = "colPrevious";
            this.colPrevious.Visible = true;
            this.colPrevious.VisibleIndex = 3;
            // 
            // colCurrent
            // 
            this.colCurrent.Caption = "本期数";
            this.colCurrent.FieldName = "Current";
            this.colCurrent.Name = "colCurrent";
            this.colCurrent.Visible = true;
            this.colCurrent.VisibleIndex = 4;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "用量(吨)";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "合计={0:0.##}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 6;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "单价";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 7;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "金额(元)";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "合计={0:0.##}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 9;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 10;
            // 
            // colCalQuantity
            // 
            this.colCalQuantity.Caption = "计算用量";
            this.colCalQuantity.FieldName = "colCalQuantity";
            this.colCalQuantity.Name = "colCalQuantity";
            this.colCalQuantity.OptionsColumn.AllowEdit = false;
            this.colCalQuantity.UnboundExpression = "[Current] - [Previous]";
            this.colCalQuantity.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCalQuantity.Visible = true;
            this.colCalQuantity.VisibleIndex = 5;
            // 
            // colCalcAmount
            // 
            this.colCalcAmount.Caption = "计算金额";
            this.colCalcAmount.FieldName = "colCalcAmount";
            this.colCalcAmount.Name = "colCalcAmount";
            this.colCalcAmount.OptionsColumn.AllowEdit = false;
            this.colCalcAmount.UnboundExpression = "[colCalQuantity] * [UnitPrice]";
            this.colCalcAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCalcAmount.Visible = true;
            this.colCalcAmount.VisibleIndex = 8;
            // 
            // WaterExpenseRecordGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "WaterExpenseRecordGrid";
            this.Size = new System.Drawing.Size(668, 378);
            this.Load += new System.EventHandler(this.WaterExpenseRecordGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCmbFeeType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn colMeterNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colMeterName;
        private DevExpress.XtraGrid.Columns.GridColumn colFeeType;
        private DevExpress.XtraGrid.Columns.GridColumn colPrevious;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrent;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCalQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repoCmbFeeType;
        private DevExpress.XtraGrid.Columns.GridColumn colCalcAmount;
    }
}