using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;

namespace PollutionCertificateGenerator
{
    public partial class frmNewCertificate : Form
    {
        frmMain mainFrm;
        CompanyData companyData;
        dataGenerator generator;
        private Capture _capture = null;
        private bool _captureInProgress;
        int started = 0;
        private Capture _capture1 = null;
        private bool _captureInProgress1;
        int prevType = 0;
        DateTime compare_date;
        public frmNewCertificate(frmMain mainFrm)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
            this.companyData = mainFrm.GetCompanyData();
            compare_date = new DateTime(2000, 3, 31);
            comboBox1.Text = "0";
            try
            {
                _capture = new Capture();
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
            try
            {
                _capture1 = new Capture(1);
                _capture1.ImageGrabbed += ProcessFrame1;
            }
            catch (NullReferenceException excpt)
            {
                //MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();

            captureImageBox.Image = frame;
        }
        private void ProcessFrame1(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> frame = _capture1.RetrieveBgrFrame();

            captureImageBox.Image = frame;
        }
        void start()
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    captureButton.Text = "Start Capture";
                    _capture.Pause();
                    //pictureBox1.Image = captureImageBox.Image.Bitmap;
                    started = 0;
                }
                else
                {
                    //start the capture
                    captureButton.Text = "Stop";
                    _capture.Start();
                    started = 1;
                }

                _captureInProgress = !_captureInProgress;
            }
        }

        void start1()
        {
            if (_capture1 != null)
            {
                if (_captureInProgress1)
                {  //stop the capture
                    captureButton.Text = "Start Capture";
                    _capture1.Pause();
                    //pictureBox1.Image = captureImageBox.Image.Bitmap;
                    started = 0;
                }
                else
                {
                    //start the capture
                    captureButton.Text = "Stop";
                    _capture1.Start();
                    started = 1;
                }

                _captureInProgress1 = !_captureInProgress1;
            }
        }

        private void captureButtonClick(object sender, EventArgs e)
        {
            if (int.Parse(comboBox1.Text) == 0)
                start();
            else
                start1();
        }

        private void ReleaseData()
        {
            if (_capture != null)
                _capture.Dispose();
            if (_capture1 != null)
                _capture1.Dispose();
        }

        private void GenerateData()
        {
            //List<CustomerDataTable> dataTable;
            //DataGridViewRow row;
            Random random = new Random();
            double co, hc;
            int iStroke, iType;
            DateTime regYear;
            iStroke = strokeStrToInt(cmb_veh_stroke.Text);
            iType = typeStrToInt(cmb_veh_type.Text);
            regYear = dtp_regYear.Value;
            double dCo;
            int iHc;
            int max_co, max_hc;
            cal_hc_co(regYear, iStroke, iType, out iHc, out dCo);
            if (iHc == 0)
            {
                iHc = 4500;
                dCo = 3.5;
            }
            max_co = (int)(dCo * 10);
            max_hc = iHc;
            if (cmb_result.Text.ToLower() == "pass")
            {
                co = random.Next(max_co-10, max_co);
                co = co / 10;
                hc = random.Next(max_hc - 1000, max_hc);
            }
            else
            {
                co = random.Next(max_co+1, max_co+10);
                co = co / 10;
                hc = random.Next(max_hc+10, max_hc+1000);
            }
            txt_co.Text = co.ToString();
            txt_hc.Text = hc.ToString();
            //dataTable = generator.GetDataTableList().GetCustomerDataTable();
            //grd_dataTable.Rows.Clear();
            //for (int i = 0; i < dataTable.Count; i++)
            //{
            //    grd_dataTable.Rows.Add();
            //    row = grd_dataTable.Rows[grd_dataTable.Rows.Count-2];
            //    row.Cells["srno"].Value = dataTable[i].SrNo;
            //    row.Cells["rpmMin"].Value = dataTable[i].RPMMin;
            //    row.Cells["rpmMax"].Value = dataTable[i].RPMMax;
            //    row.Cells["oilTemp"].Value = dataTable[i].OILTemp;
            //    row.Cells["kVal"].Value = String.Format("{0:0.00}", dataTable[i].KVal);
            //    row.Cells["hsuPer"].Value = String.Format("{0:00.00}", dataTable[i].HSUPer);
            //    //grd_dataTable.Rows.Add(row);
            //}
            //txt_kval.Text = String.Format("{0:0.00}", generator.AvgKVAL);
            //txt_hsuper.Text = String.Format("{0:00.00}",  generator.AvgHSUPer);
            if (co < max_co && hc < max_hc)
            {
                txt_result.Text = "PASS";

            }
            else
            {
                txt_result.Text = "Failed";
            }
        }
        public void Clear()
        {
            DateTime val;
            txt_vehNo.Text = "";
            cmb_category.Text = "";
            txt_dateOn.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cmb_vehMake.Text = "";
            cmb_vehModel.Text = "";
            txt_fuelTupe.Text = "PETROL";
            txt_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
            val = DateTime.Now;
            val = val.AddYears(companyData.GetValYear()).AddMonths(companyData.GetValMonth()).AddDays(-1);
            txt_validUpto.Text = val.ToString("dd/MM/yyyy");
            //grd_dataTable.Rows.Clear();
            txt_fare.Text = "100";
            cmb_result.SelectedIndex = 0;
            cmb_veh_stroke.SelectedIndex = 0;
            cmb_veh_type.SelectedIndex = 0;
            GenerateData();
        }
        public String Fare
        {
            get
            {
                return txt_fare.Text;
            }
        }
        private void frmNewCertificate_Load(object sender, EventArgs e)
        {
            generator = new dataGenerator();
            Clear();
        }

        private void frmNewCertificate_Leave(object sender, EventArgs e)
        {
            mainFrm.ChildDestroy(frmName.e_frm_newCertificate);
        }
        private bool CheckValue()
        {
            if (txt_vehNo.Text == "")
                return false;
            if (cmb_category.Text == "")
                return false;
            if (txt_dateOn.Text == "")
                return false;
            if (cmb_vehMake.Text == "")
                return false;
            if (cmb_vehModel.Text == "")
                return false;
            if (txt_fuelTupe.Text == "")
                return false;
            if (txt_time.Text == "")
                return false;
            //if (grd_dataTable.RowCount == 0)
            //    return false;
            return true;
        }
        private bool CreateData(ref CustomerData data, ref CustomerDataTableList dataTable)
        {
            CustomerDataTable tmpTable = new CustomerDataTable();
            String imagePath;
            bool ret = CheckValue();
            if (!ret)
                return ret;
            imagePath = Helper.SaveImageCapture(captureImageBox.Image.Bitmap, txt_vehNo.Text);
            int iHc;
            double dCo;
            cal_hc_co(dtp_regYear.Value, strokeStrToInt(cmb_veh_stroke.Text), typeStrToInt(cmb_veh_type.Text), out iHc, out dCo);
            if (iHc == 0)
            {
                iHc = 4500;
                dCo = 3.5;
            }
            data.AddCustomerData(txt_vehNo.Text,
                                cmb_category.Text,
                                cmb_vehMake.Text,
                                cmb_vehModel.Text,
                                txt_fuelTupe.Text,
                                txt_validUpto.Text,
                                dtp_regYear.Value,
                                txt_result.Text,
                                imagePath,
                                txt_co.Text,
                                txt_hc.Text,
                                dCo.ToString(),
                                iHc.ToString());
            //dataTable = generator.GetDataTableList();
#if XMLDone
            for (int i = 0; i < grd_dataTable.RowCount-1; i++)
            {
                tmpSrno = Convert.ToInt32(grd_dataTable.Rows[i].Cells["srno"].Value.ToString());
                tmpRmpMin = Convert.ToInt32(grd_dataTable.Rows[i].Cells["rpmMin"].Value.ToString());
                tmpRpmMax = Convert.ToInt32(grd_dataTable.Rows[i].Cells["rpmMax"].Value.ToString());
                tmpOilTemp = Convert.ToInt32(grd_dataTable.Rows[i].Cells["oilTemp"].Value.ToString());
                tmpKval = Convert.ToDouble(grd_dataTable.Rows[i].Cells["kVal"].Value.ToString());
                tmpHsuper = Convert.ToDouble(grd_dataTable.Rows[i].Cells["hsuPer"].Value.ToString());
                
                tmpTable.AddCustomerDataTable(tmpSrno, tmpRmpMin, tmpRpmMax, tmpOilTemp, tmpKval, tmpHsuper);
                dataTable.AddData(tmpTable);
            }
#endif
            return true;
        }
        private bool Validate()
        {
            if (txt_vehNo.Text.Trim() == "" || 
                cmb_vehMake.Text.Trim() == "" || 
                cmb_vehModel.Text.Trim() == "")
                return false;
            /*if (pictureBox1.Image == null)
                return false;*/
            //if (grd_dataTable.Rows.Count <= 2)
            //    return false;
            return true;
        }
        public bool Print(ref CustomerData data, ref CustomerDataTableList dataTable)
        {
            if (!Validate())
                return false;
            return CreateData(ref data, ref dataTable);                   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void save()
        {

        }
        private void GetImageDelegate(Image getImage)
        {
            pictureBox1.Image = getImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                captureImageBox.Image = new Image<Bgr, Byte>(bmp);
            }
        }

        private void cmb_category_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (started == 1)
            {
                if (prevType == 0)
                    start();
                else
                    start1();
            }

            /*if (int.Parse(comboBox1.Text) == 0)
            {
                start();
            }
            else
            {
                start1();
            }*/

            prevType = int.Parse(comboBox1.Text);
        }

        private void cmb_result_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateData();
        }

        private void dtp_regYear_ValueChanged(object sender, EventArgs e)
        {
            Update_HC_CO();
        }
        private void Update_HC_CO()
        {
            int iStroke = strokeStrToInt(cmb_veh_stroke.Text);
            int iVehType = typeStrToInt(cmb_veh_type.Text);
            DateTime regYear = dtp_regYear.Value;
            String sHc = "HC/PPM (MAX {0})";
            String sCo = "CO% (MAC {0})";
            int hc;
            double co;

            cal_hc_co(regYear, iStroke, iVehType, out hc, out co);
            if (hc == 0)
                return;
            lbl_hc.Text = String.Format(sHc, hc);
            lbl_co.Text = String.Format(sCo, co);
            GenerateData();
        }
        private int strokeStrToInt(String stroke)
        {
            int iStroke = 0;
            switch(stroke)
            {
                case "4 Stroke":
                    iStroke =  4;
                    break;
                case "2 Stroke":
                    iStroke = 2;
                    break;
            }
            return iStroke;
        }
        private int typeStrToInt(String stroke)
        {
            int vehType = 0;
            switch(stroke)
            {
                case "4 Wheeler":
                    vehType = 4;
                    break;
                case "3 Wheeler":
                    vehType = 3;
                    break;
                case "2 Wheeler":
                    vehType = 2;
                    break;
            }
            return vehType;
        }
        private void cal_hc_co(DateTime regYear, int iStroke, int iVehType, out int std_hc, out double std_co)
        {
            int cmp = DateTime.Compare(regYear, compare_date);
            std_co = 0;
            std_hc = 0;
            if (iStroke <= 0)
                return;

            if (iVehType == 4)
            {
                std_hc = 1500;
                std_co = 3.0;
            }
            else if ((iVehType == 2 || iVehType == 3) && cmp <= 0)
            {
                std_hc = 9000;
                std_co = 4.5;
            }
            else if ((iVehType == 2 || iVehType == 3) && cmp > 0 && iStroke == 2)
            {
                std_hc = 6000;
                std_co = 3.5;
            }
            else if ((iVehType == 2 || iVehType == 3) && cmp > 0 && iStroke == 4)
            {
                std_hc = 4500;
                std_co = 3.5;
            }
        }

        private void cmb_veh_stroke_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update_HC_CO();
        }

    }   
    public class Helper
    {

        public static String SaveImageCapture(System.Drawing.Image image, String fileName)
        {

            //SaveFileDialog s = new SaveFileDialog();
            //s.FileName = fileName;// Default file name
            //s.DefaultExt = ".Jpg";// Default file extension
            //s.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            //// Show save file dialog box
            //// Process save file dialog box results
            //if (s.ShowDialog()==DialogResult.OK)
            {
                // Save Image
                String filename = Directory.GetCurrentDirectory() + "\\" + fileName + ".jpg";
                FileStream fstream;
                if (image == null)
                    return null;
                if (File.Exists(filename))
                    File.Delete(filename);
                fstream = new FileStream(filename, FileMode.Create);
                image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();
                return filename;
            }

        }
    }
}
