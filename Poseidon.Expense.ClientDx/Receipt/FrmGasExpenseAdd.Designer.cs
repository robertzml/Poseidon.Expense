﻿namespace Poseidon.Expense.ClientDx
{
    partial class FrmGasExpenseAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbFeeType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnSum = new DevExpress.XtraEditors.SimpleButton();
            this.spTotalAmount = new DevExpress.XtraEditors.SpinEdit();
            this.spTotalQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.dpTicketDate = new DevExpress.XtraEditors.DateEdit();
            this.dpBelongDate = new DevExpress.XtraEditors.DateEdit();
            this.txtAccountName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.expenseGrid = new Poseidon.Expense.ClientDx.GasExpenseRecordGrid();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.previousGrid = new Poseidon.Expense.ClientDx.GasExpenseRecordGrid();
            this.txtPreviousDate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uploadTool = new Poseidon.Archives.Utility.AttachmentUploadTool();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).BeginInit();
            this.plFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFeeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTicketDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTicketDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpBelongDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpBelongDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(787, 15);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(678, 15);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.tableLayoutPanel1);
            this.plFill.Size = new System.Drawing.Size(884, 542);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Location = new System.Drawing.Point(0, 542);
            this.plBottom.Size = new System.Drawing.Size(884, 60);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(878, 154);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "支出信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uploadTool);
            this.layoutControl1.Controls.Add(this.cmbFeeType);
            this.layoutControl1.Controls.Add(this.btnSum);
            this.layoutControl1.Controls.Add(this.spTotalAmount);
            this.layoutControl1.Controls.Add(this.spTotalQuantity);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.dpTicketDate);
            this.layoutControl1.Controls.Add(this.dpBelongDate);
            this.layoutControl1.Controls.Add(this.txtAccountName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(874, 131);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbFeeType
            // 
            this.cmbFeeType.Location = new System.Drawing.Point(555, 12);
            this.cmbFeeType.Name = "cmbFeeType";
            this.cmbFeeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFeeType.Size = new System.Drawing.Size(173, 20);
            this.cmbFeeType.StyleController = this.layoutControl1;
            this.cmbFeeType.TabIndex = 3;
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(12, 97);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(285, 22);
            this.btnSum.StyleController = this.layoutControl1;
            this.btnSum.TabIndex = 11;
            this.btnSum.Text = "求和";
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // spTotalAmount
            // 
            this.spTotalAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spTotalAmount.Location = new System.Drawing.Point(396, 36);
            this.spTotalAmount.Name = "spTotalAmount";
            this.spTotalAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spTotalAmount.Size = new System.Drawing.Size(332, 20);
            this.spTotalAmount.StyleController = this.layoutControl1;
            this.spTotalAmount.TabIndex = 5;
            // 
            // spTotalQuantity
            // 
            this.spTotalQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spTotalQuantity.Location = new System.Drawing.Point(97, 36);
            this.spTotalQuantity.Name = "spTotalQuantity";
            this.spTotalQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spTotalQuantity.Size = new System.Drawing.Size(210, 20);
            this.spTotalQuantity.StyleController = this.layoutControl1;
            this.spTotalQuantity.TabIndex = 4;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(97, 60);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(631, 33);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 6;
            // 
            // dpTicketDate
            // 
            this.dpTicketDate.EditValue = null;
            this.dpTicketDate.Location = new System.Drawing.Point(396, 12);
            this.dpTicketDate.Name = "dpTicketDate";
            this.dpTicketDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpTicketDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpTicketDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpTicketDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpTicketDate.Size = new System.Drawing.Size(70, 20);
            this.dpTicketDate.StyleController = this.layoutControl1;
            this.dpTicketDate.TabIndex = 2;
            // 
            // dpBelongDate
            // 
            this.dpBelongDate.EditValue = null;
            this.dpBelongDate.Location = new System.Drawing.Point(241, 12);
            this.dpBelongDate.Name = "dpBelongDate";
            this.dpBelongDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpBelongDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpBelongDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpBelongDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dpBelongDate.Properties.Mask.EditMask = "y";
            this.dpBelongDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dpBelongDate.Properties.ShowToday = false;
            this.dpBelongDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpBelongDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.dpBelongDate.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)(((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.CenturyView)));
            this.dpBelongDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dpBelongDate.Size = new System.Drawing.Size(66, 20);
            this.dpBelongDate.StyleController = this.layoutControl1;
            this.dpBelongDate.TabIndex = 1;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(97, 12);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtAccountName.Properties.Appearance.Options.UseBackColor = true;
            this.txtAccountName.Properties.ReadOnly = true;
            this.txtAccountName.Size = new System.Drawing.Size(55, 20);
            this.txtAccountName.StyleController = this.layoutControl1;
            this.txtAccountName.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlItem11,
            this.layoutControlItem10});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(874, 131);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtAccountName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(144, 24);
            this.layoutControlItem1.Text = "账户名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(82, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dpBelongDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(144, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(155, 24);
            this.layoutControlItem2.Text = "归属日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(82, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dpTicketDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(299, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(159, 24);
            this.layoutControlItem3.Text = "票据日期";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(82, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRemark;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(720, 37);
            this.layoutControlItem4.Text = "备注";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.spTotalQuantity;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(299, 24);
            this.layoutControlItem6.Text = "总用气量(立方)";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(82, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.spTotalAmount;
            this.layoutControlItem7.Location = new System.Drawing.Point(299, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(421, 24);
            this.layoutControlItem7.Text = "总金额(元)";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(82, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSum;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 85);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(289, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(289, 85);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(431, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.cmbFeeType;
            this.layoutControlItem11.Location = new System.Drawing.Point(458, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(262, 24);
            this.layoutControlItem11.Text = "费用类型";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(82, 14);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.expenseGrid);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 163);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(878, 194);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "支出明细";
            // 
            // expenseGrid
            // 
            this.expenseGrid.AllowFilter = false;
            this.expenseGrid.AllowGroup = false;
            this.expenseGrid.AllowSort = false;
            this.expenseGrid.DataSource = null;
            this.expenseGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expenseGrid.Editable = true;
            this.expenseGrid.EnableMasterView = false;
            this.expenseGrid.EnableMultiSelect = false;
            this.expenseGrid.Location = new System.Drawing.Point(2, 21);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.ShowAddMenu = false;
            this.expenseGrid.ShowFooter = true;
            this.expenseGrid.ShowLineNumber = true;
            this.expenseGrid.ShowMenu = false;
            this.expenseGrid.ShowNavigator = true;
            this.expenseGrid.Size = new System.Drawing.Size(874, 171);
            this.expenseGrid.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.layoutControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 363);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(878, 176);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "上期记录";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.previousGrid);
            this.layoutControl2.Controls.Add(this.txtPreviousDate);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 21);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(874, 153);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // previousGrid
            // 
            this.previousGrid.AllowFilter = false;
            this.previousGrid.AllowGroup = false;
            this.previousGrid.AllowSort = false;
            this.previousGrid.DataSource = null;
            this.previousGrid.Editable = false;
            this.previousGrid.EnableMasterView = false;
            this.previousGrid.EnableMultiSelect = false;
            this.previousGrid.Location = new System.Drawing.Point(2, 26);
            this.previousGrid.Name = "previousGrid";
            this.previousGrid.ShowAddMenu = false;
            this.previousGrid.ShowFooter = false;
            this.previousGrid.ShowLineNumber = true;
            this.previousGrid.ShowMenu = false;
            this.previousGrid.ShowNavigator = false;
            this.previousGrid.Size = new System.Drawing.Size(870, 125);
            this.previousGrid.TabIndex = 5;
            // 
            // txtPreviousDate
            // 
            this.txtPreviousDate.Location = new System.Drawing.Point(53, 2);
            this.txtPreviousDate.Name = "txtPreviousDate";
            this.txtPreviousDate.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtPreviousDate.Properties.Appearance.Options.UseBackColor = true;
            this.txtPreviousDate.Properties.ReadOnly = true;
            this.txtPreviousDate.Size = new System.Drawing.Size(819, 20);
            this.txtPreviousDate.StyleController = this.layoutControl2;
            this.txtPreviousDate.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem9});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(874, 153);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPreviousDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(874, 24);
            this.layoutControlItem5.Text = "上期日期";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.previousGrid;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(874, 129);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // uploadTool
            // 
            this.uploadTool.Location = new System.Drawing.Point(732, 12);
            this.uploadTool.Name = "uploadTool";
            this.uploadTool.Size = new System.Drawing.Size(130, 107);
            this.uploadTool.TabIndex = 12;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.uploadTool;
            this.layoutControlItem10.Location = new System.Drawing.Point(720, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(134, 111);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // FrmGasExpenseAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 602);
            this.Name = "FrmGasExpenseAdd";
            this.Text = "登记气费支出";
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).EndInit();
            this.plFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFeeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTicketDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTicketDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpBelongDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpBelongDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbFeeType;
        private DevExpress.XtraEditors.SimpleButton btnSum;
        private DevExpress.XtraEditors.SpinEdit spTotalAmount;
        private DevExpress.XtraEditors.SpinEdit spTotalQuantity;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.DateEdit dpTicketDate;
        private DevExpress.XtraEditors.DateEdit dpBelongDate;
        private DevExpress.XtraEditors.TextEdit txtAccountName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private GasExpenseRecordGrid expenseGrid;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private GasExpenseRecordGrid previousGrid;
        private DevExpress.XtraEditors.TextEdit txtPreviousDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private Archives.Utility.AttachmentUploadTool uploadTool;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}