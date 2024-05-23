namespace prjPayroll
{
    partial class frmPayroll
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentWindow1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.grdPayroll = new Telerik.WinControls.UI.RadGridView();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.toolWindow1 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.btnLogOut = new Telerik.WinControls.UI.RadButton();
            this.btnPayroll = new Telerik.WinControls.UI.RadButton();
            this.btnEmp = new Telerik.WinControls.UI.RadButton();
            this.btnDash = new Telerik.WinControls.UI.RadButton();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            this.documentWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayroll.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
            this.toolWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1232, 125);
            this.radPanel1.TabIndex = 1;
            this.radPanel1.Text = "PAYROLL SYSTEM";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radDock1
            // 
            this.radDock1.ActiveWindow = this.toolWindow1;
            this.radDock1.CausesValidation = false;
            this.radDock1.Controls.Add(this.toolTabStrip1);
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 125);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.Size = new System.Drawing.Size(1232, 328);
            this.radDock1.TabIndex = 2;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            // 
            // documentWindow1
            // 
            this.documentWindow1.Controls.Add(this.grdPayroll);
            this.documentWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.documentWindow1.Location = new System.Drawing.Point(6, 29);
            this.documentWindow1.Name = "documentWindow1";
            this.documentWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow1.Size = new System.Drawing.Size(1006, 283);
            this.documentWindow1.Text = "Payroll";
            // 
            // grdPayroll
            // 
            this.grdPayroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.grdPayroll.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPayroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPayroll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdPayroll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPayroll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdPayroll.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.grdPayroll.MasterTemplate.AllowAddNewRow = false;
            this.grdPayroll.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "id";
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "userId";
            gridViewTextBoxColumn2.HeaderText = "ID";
            gridViewTextBoxColumn2.Name = "userId";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "week";
            gridViewTextBoxColumn3.HeaderText = "Week";
            gridViewTextBoxColumn3.Name = "week";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "name";
            gridViewTextBoxColumn4.HeaderText = "Name";
            gridViewTextBoxColumn4.Name = "name";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "position";
            gridViewTextBoxColumn5.HeaderText = "Position";
            gridViewTextBoxColumn5.Name = "position";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "rate";
            gridViewTextBoxColumn6.FormatString = "{0:G}";
            gridViewTextBoxColumn6.HeaderText = "Rate";
            gridViewTextBoxColumn6.Name = "rate";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "days";
            gridViewTextBoxColumn7.FormatString = "{0:G}";
            gridViewTextBoxColumn7.HeaderText = "Days";
            gridViewTextBoxColumn7.Name = "days";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "late";
            gridViewTextBoxColumn8.HeaderText = "Late";
            gridViewTextBoxColumn8.Name = "late";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "salary";
            gridViewTextBoxColumn9.HeaderText = "Salary";
            gridViewTextBoxColumn9.Name = "salary";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.Expression = "=((rate/8)+(rate/8)*0.2)";
            gridViewTextBoxColumn10.FieldName = "rph";
            gridViewTextBoxColumn10.FormatString = "{0:G}";
            gridViewTextBoxColumn10.HeaderText = "Rate Per Hour";
            gridViewTextBoxColumn10.Name = "rph";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 75;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "hours";
            gridViewTextBoxColumn11.HeaderText = "Hours";
            gridViewTextBoxColumn11.Name = "hours";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "otPay";
            gridViewTextBoxColumn12.HeaderText = "Overtime Pay";
            gridViewTextBoxColumn12.Name = "otPay";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 100;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "holiday";
            gridViewTextBoxColumn13.HeaderText = "Holiday";
            gridViewTextBoxColumn13.Name = "holiday";
            gridViewTextBoxColumn13.Width = 100;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "philhealth";
            gridViewTextBoxColumn14.HeaderText = "philHealth";
            gridViewTextBoxColumn14.Name = "philhealth";
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "sss";
            gridViewTextBoxColumn15.HeaderText = "SSS";
            gridViewTextBoxColumn15.Name = "sss";
            gridViewTextBoxColumn15.Width = 100;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "advance";
            gridViewTextBoxColumn16.HeaderText = "Advance";
            gridViewTextBoxColumn16.Name = "advance";
            gridViewTextBoxColumn16.Width = 100;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "total";
            gridViewTextBoxColumn17.HeaderText = "Total";
            gridViewTextBoxColumn17.Name = "total";
            gridViewTextBoxColumn17.ReadOnly = true;
            gridViewTextBoxColumn17.Width = 100;
            this.grdPayroll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17});
            this.grdPayroll.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdPayroll.MasterTemplate.EnableFiltering = true;
            this.grdPayroll.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdPayroll.Name = "grdPayroll";
            this.grdPayroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdPayroll.Size = new System.Drawing.Size(1006, 283);
            this.grdPayroll.TabIndex = 0;
            this.grdPayroll.Text = "radGridView1";
            this.grdPayroll.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.MasterTemplate_CellEndEdit);
            // 
            // toolTabStrip1
            // 
            this.toolTabStrip1.CanUpdateChildIndex = true;
            this.toolTabStrip1.Controls.Add(this.toolWindow1);
            this.toolTabStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolTabStrip1.Name = "toolTabStrip1";
            // 
            // 
            // 
            this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.toolTabStrip1.SelectedIndex = 0;
            this.toolTabStrip1.Size = new System.Drawing.Size(200, 318);
            this.toolTabStrip1.TabIndex = 1;
            this.toolTabStrip1.TabStop = false;
            // 
            // toolWindow1
            // 
            this.toolWindow1.Caption = null;
            this.toolWindow1.Controls.Add(this.btnLogOut);
            this.toolWindow1.Controls.Add(this.btnPayroll);
            this.toolWindow1.Controls.Add(this.btnEmp);
            this.toolWindow1.Controls.Add(this.btnDash);
            this.toolWindow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.toolWindow1.Location = new System.Drawing.Point(1, 24);
            this.toolWindow1.Name = "toolWindow1";
            this.toolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow1.Size = new System.Drawing.Size(198, 292);
            this.toolWindow1.Text = "Tabs";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(25, 140);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(150, 30);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "LOG OUT";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnPayroll
            // 
            this.btnPayroll.Location = new System.Drawing.Point(25, 104);
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.Size = new System.Drawing.Size(150, 30);
            this.btnPayroll.TabIndex = 6;
            this.btnPayroll.Text = "PAYROLL";
            this.btnPayroll.Click += new System.EventHandler(this.btnPayroll_Click);
            // 
            // btnEmp
            // 
            this.btnEmp.BackColor = System.Drawing.Color.White;
            this.btnEmp.ForeColor = System.Drawing.Color.Lime;
            this.btnEmp.Location = new System.Drawing.Point(25, 68);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(150, 30);
            this.btnEmp.TabIndex = 5;
            this.btnEmp.Text = "EMPLOYEE";
            this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
            // 
            // btnDash
            // 
            this.btnDash.Location = new System.Drawing.Point(25, 32);
            this.btnDash.Name = "btnDash";
            this.btnDash.Size = new System.Drawing.Size(150, 30);
            this.btnDash.TabIndex = 4;
            this.btnDash.Text = "HOMEPAGE";
            // 
            // documentContainer1
            // 
            this.documentContainer1.CausesValidation = false;
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.TabIndex = 2;
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.CanUpdateChildIndex = true;
            this.documentTabStrip1.CausesValidation = false;
            this.documentTabStrip1.Controls.Add(this.documentWindow1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(1018, 318);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            // 
            // frmPayroll
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1232, 453);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmPayroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll";
            this.Load += new System.EventHandler(this.frmPayroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            this.documentWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPayroll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
            this.toolTabStrip1.ResumeLayout(false);
            this.toolWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.ToolWindow toolWindow1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;
        private Telerik.WinControls.UI.RadButton btnLogOut;
        private Telerik.WinControls.UI.RadButton btnPayroll;
        private Telerik.WinControls.UI.RadButton btnEmp;
        private Telerik.WinControls.UI.RadButton btnDash;
        private Telerik.WinControls.UI.RadGridView grdPayroll;
    }
}