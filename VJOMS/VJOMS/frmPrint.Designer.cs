namespace VJOMS
{
    partial class frmPrint
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dsVJOMSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsVJOMS = new VJOMS.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtVJOMSTableAdapter = new VJOMS.DataSet1TableAdapters.dtVJOMSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsVJOMSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVJOMS)).BeginInit();
            this.SuspendLayout();
            // 
            // dsVJOMSBindingSource
            // 
            this.dsVJOMSBindingSource.DataMember = "dtVJOMS";
            this.dsVJOMSBindingSource.DataSource = this.dsVJOMS;
            // 
            // dsVJOMS
            // 
            this.dsVJOMS.DataSetName = "DataSet1";
            this.dsVJOMS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rptVJOMS";
            reportDataSource1.Value = this.dsVJOMSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VJOMS.rptVJOMS.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(808, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtVJOMSTableAdapter
            // 
            this.dtVJOMSTableAdapter.ClearBeforeFill = true;
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 461);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsVJOMSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVJOMS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1 dsVJOMS;
        private System.Windows.Forms.BindingSource dsVJOMSBindingSource;
        private DataSet1TableAdapters.dtVJOMSTableAdapter dtVJOMSTableAdapter;
    }
}