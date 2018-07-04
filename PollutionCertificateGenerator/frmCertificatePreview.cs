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
    using CompanyDataList = DataList<CompanyData>;
    using CustomerDataTableList = DataList<CustomerDataTable>;
    using CustomerDataList = DataList<CustomerData>;
    using CustomerDataTablePetrolList = DataList<CustomerDataTablePetrol>;
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
                                    CustomerDataTableList customerDataTable,
                                    CustomerDataTablePetrolList customerDataTablePetrol)
        {
            CompanyDataList tmpCompanyData = new CompanyDataList();
            CustomerDataList tmpCustomerData = new CustomerDataList();
            tmpCompanyData.AddData(companyData);
            tmpCustomerData.AddData(customerData);
            this.CompanyDataBindingSource.DataSource = tmpCompanyData.GetData();
            this.CustomerDataBindingSource.DataSource = tmpCustomerData.GetData();
            this.CustomerDataTableBindingSource.DataSource = null;
            this.CustomerDataTablePetrolBindingSource.DataSource = null;
            if (customerDataTable != null)
                this.CustomerDataTableBindingSource.DataSource = customerDataTable.GetData();
            if (customerDataTablePetrol != null)
                this.CustomerDataTablePetrolBindingSource.DataSource = customerDataTablePetrol.GetData();
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

        private void CustomerDataTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
