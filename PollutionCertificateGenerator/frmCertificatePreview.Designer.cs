namespace PollutionCertificateGenerator
{
    partial class frmCertificatePreview
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CompanyDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSCompanyData";
            reportDataSource1.Value = this.CompanyDataBindingSource;
            reportDataSource2.Name = "DSCustomerDataTable";
            reportDataSource2.Value = this.CustomerDataTableBindingSource;
            reportDataSource3.Name = "CustomerData";
            reportDataSource3.Value = this.CustomerDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PollutionCertificateGenerator.a4by2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(526, 477);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // CompanyDataBindingSource
            // 
            this.CompanyDataBindingSource.DataSource = typeof(PollutionCertificateGenerator.CompanyData);
            // 
            // CustomerDataBindingSource
            // 
            this.CustomerDataBindingSource.DataSource = typeof(PollutionCertificateGenerator.CustomerData);
            // 
            // CustomerDataTableBindingSource
            // 
            this.CustomerDataTableBindingSource.DataSource = typeof(PollutionCertificateGenerator.CustomerDataTable);
            // 
            // frmCertificatePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 477);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmCertificatePreview";
            this.Text = "Certificate Preview";
            this.Load += new System.EventHandler(this.frmCertificatePreview_Load);
            this.Leave += new System.EventHandler(this.frmCertificatePreview_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CustomerDataTableBindingSource;
        private System.Windows.Forms.BindingSource CustomerDataBindingSource;
        private System.Windows.Forms.BindingSource CompanyDataBindingSource;

    }
}