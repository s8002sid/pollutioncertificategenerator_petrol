using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PollutionCertificateGenerator
{
    public partial class frmCertificatePreview : Form
    {
        private frmMain mainFrm;
        public frmCertificatePreview(frmMain mainFrm)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
        }

        private void frmCertificatePreview_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            Refresh1();
        }
        private void Refresh1()
        {
            this.reportViewer1.RefreshReport();
        }
        public void GetData(CustomerDataList dataList)
        {

        }

        private void frmCertificatePreview_Leave(object sender, EventArgs e)
        {
            mainFrm.ChildDestroy(frmName.e_frm_certificatePreview);
        }
        public void SetDataBindings(CompanyData companyData,
                                    CustomerData customerData,
                                    CustomerDataTableList customerDataTable)
        {
            CompanyDataList tmpCompanyData = new CompanyDataList();
            CustomerDataList tmpCustomerData = new CustomerDataList();
            tmpCompanyData.AddData(companyData);
            tmpCustomerData.AddData(customerData);
            this.CompanyDataBindingSource.DataSource = tmpCompanyData.GetCompanyData();
            this.CustomerDataBindingSource.DataSource = tmpCustomerData.GetCustomerData();
            this.CustomerDataTableBindingSource.DataSource = customerDataTable.GetCustomerDataTable();
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.DisplayName = customerData.VehNo.ToString();
            Refresh1();
        }
        public void Print()
        {
            reportViewer1.PrintDialog();
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
