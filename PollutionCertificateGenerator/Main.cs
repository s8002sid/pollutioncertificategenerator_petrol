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
    using CustomerDataTableList = DataList<CustomerDataTable>;
    using CustomerDataTablePetrolList = DataList<CustomerDataTablePetrol>;
    public partial class frmMain : Form
    {
        /// <summary>
        /// Private Variables
        /// </summary>
        public frmNewCertificate newCertificate;
        public frmCertificatePreview certificatePreview;
        private CompanyData companyData;
        private CustomerData customerData;
        private CustomerDataTable customerDataTable;
        private PasswordBox pbox;
        /// <summary>
        /// Public Functions
        /// </summary>
        public void ChildDestroy(frmName frm)
        {
            switch (frm)
            {
                case frmName.e_frm_certificatePreview:
                    certificatePreview = null;
                    break;
                case frmName.e_frm_newCertificate:
                    newCertificate = null;
                    break;
            }
            toolStrip.Visible = true;
        }

        /// <summary>
        /// User Functions
        /// </summary>
        private void ShowNewCertificate()
        {
            if (newCertificate == null)
            {
                newCertificate = new frmNewCertificate(this);
                newCertificate.MdiParent = this;
            }
            if (certificatePreview != null)
            {
                certificatePreview.Dispose();
                certificatePreview = null;
            }
            newCertificate.WindowState = FormWindowState.Maximized;
            newCertificate.Visible = true;
            newCertificate.Show();
            newCertificate.BringToFront();
            toolStrip.Visible = true;
        }
        private void ShowCertificatePreview(CompanyData company, CustomerData customer, CustomerDataTableList dataTable, CustomerDataTablePetrolList dataTablePetrol)
        {
            if (certificatePreview != null)
            {
                certificatePreview.Dispose();
            }

            certificatePreview = new frmCertificatePreview(this);
            certificatePreview.MdiParent = this;

            certificatePreview.SetDataBindings(company, customer, dataTable, dataTablePetrol);

            certificatePreview.WindowState = FormWindowState.Maximized;
            certificatePreview.Show();
            certificatePreview.BringToFront();
            toolStrip.Visible = false;
        }

        private error_certificate Print()
        {
            //CustomerDataList dataList = new CustomerDataList();
            CustomerData data = new CustomerData();
            CustomerDataTablePetrolList dataTableList = new CustomerDataTablePetrolList();
            CompanyData company = new CompanyData();
            if (newCertificate == null)
                if (certificatePreview == null)
                {
                    return error_certificate.error_NoData;
                }
                else
                {
                    certificatePreview.Print();
                    return error_certificate.error_Success;
                }

            company.AddFare(int.Parse(newCertificate.Fare));
            if(!newCertificate.Print(ref data, ref dataTableList))
            {
                return error_certificate.error_NullValue;
            }
            newCertificate.Visible = false;
            ShowCertificatePreview(company, data, null, dataTableList);

            return error_certificate.error_Success;
        }

        /// <summary>
        /// System Generated Functions
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            newCertificate = null;
            certificatePreview = null;
            //this.pbox = pbox;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewCertificate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Print() != error_certificate.error_Success)
            {
                MessageBox.Show("Unable to show print preview", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PasswordBox pbox = new PasswordBox();
            //pbox.MdiParent = this;
            pbox.ShowDialog();
#if !XMLDone
            this.companyData = new CompanyData();
            this.customerData = new CustomerData();
            this.customerDataTable = new CustomerDataTable();
            ShowNewCertificate();
#endif
        }
        public CompanyData GetCompanyData()
        {
            return this.companyData;
        }
        public CustomerData GetCustomerData()
        {
            return this.customerData;
        }
        public CustomerDataTable GetCustomerDataTable()
        {
            return this.customerDataTable;
        }

        public void SetCompanyData(CompanyData companyData)
        {
            this.companyData = companyData;
        }
        public void SetCustomerData(CustomerData data)
        {
            this.customerData = data;
        }
        public void SetCustomerDataTable(CustomerDataTable data)
        {
            this.customerDataTable = data;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Clear()
        {
            if (newCertificate != null && newCertificate.Visible != false)
            {
                newCertificate.Clear();
            }
        }

        private void clearDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void frmMain_Leave(object sender, EventArgs e)
        {
            //pbox.Dispose();
            //pbox.Exit();
            //Environment.Exit(1);
        }
    }
}
