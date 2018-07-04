using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollutionCertificateGenerator
{
    using CompanyDataList = DataList<CompanyData>;
    using CustomerDataTableList = DataList<CustomerDataTable>;
    using CustomerDataList = DataList<CustomerData>;
    using CustomerDataTablePetrolList = DataList<CustomerDataTablePetrol>;
    public class DataList<T>
    {
        private List<T> data;
        public DataList()
        {
            data = new List<T>();
        }

        public void AddData(T data)
        {
            this.data.Add(data);
        }

        public List<T> GetData()
        {
            return data;
        }
    }
    public class CompanyData
    {
        private String name, address, contactNo, liscenceNo;
        private String idNo, narration;
        private Int32 testFee, passPercent, valYear, valMonth;
#if XMLDone
        public CompanyData()
        {
            this.name = "";
            this.address = "";
            this.contactNo = "0000000000";
            this.liscenceNo = "";
            this.idNo = "";
            this.narration = "";
            this.testFee = 0;
            this.passPercent = 0;
            this.valYear = 0;
            this.valMonth = 0;
        }
#else
        public CompanyData()
        {
            this.name = "MAHAVIR POLLUTION TESTING CENTER";
            this.address = "RTO CAMPUS,\n RANWA BHATTA,\n RAIPUR (C.G.)";
            this.contactNo = "9826198612";
            this.liscenceNo = "01/2015";
            this.idNo = "14,727";
            this.narration = "Certificate that the vehicle meets emmission"
                              + "standard prescribed by under the Rule " 
                              +  "115(2) of CVM Rules 1989. "
                              + "The certificate is valid for 6 months";
            this.testFee = 50;
            this.passPercent = 65;
            this.valYear = 0;
            this.valMonth = 6;
        }
#endif

        public CompanyData(String name,
                            String address,
                            String contactNo,
                            String liscenceNo,
                            String idNo,
                            String narration,
                            Int32 testFee,
                            Int32 passPercent,
                            Int32 valYear,
                            Int32 valMonth)
        {
            this.name = name;
            this.address = address;
            this.contactNo = contactNo;
            this.liscenceNo = liscenceNo;
            this.idNo = idNo;
            this.narration = narration;
            this.testFee = testFee;
            this.passPercent = passPercent;
            this.valYear = valYear;
            this.valMonth = valMonth;
        }

        public void AddCompanyData(String name,
                            String address,
                            String contactNo,
                            String liscenceNo,
                            String idNo,
                            String narration,
                            Int32 testFee,
                            Int32 passPercent,
                            Int32 valYear,
                            Int32 valMonth)
        {
            this.name = name;
            this.address = address;
            this.contactNo = contactNo;
            this.liscenceNo = liscenceNo;
            this.idNo = idNo;
            this.narration = narration;
            this.testFee = testFee;
            this.passPercent = passPercent;
            this.valYear = valYear;
            this.valMonth = valMonth;
        }
        public void AddFare(int testFee) 
        {
            this.testFee = testFee;
        }
        public String Name { get { return name; } }
        public String Address { get { return address; } }
        public String ContactNo { get { return contactNo; } }
        public String LiscenceNo { get { return liscenceNo; } }
        public String IDNo
        {
            get
            {
                return idNo;
            }
        }
        public String Narration
        {
            get
            {
                return narration;
            }
        }
        public Int32 TestFee
        {
            get
            {
                return testFee;
            }
        }
        public Int32 PassPer
        {
            get
            {
                return passPercent;
            }
        }
        public String Validity
        {
            get
            {
                String valstr = "";
                if (valYear != 0)
                    valstr += valYear.ToString() + " Year";
                if (valMonth != 0)
                    valstr += valMonth.ToString() + " Month";

                return valstr;
            }
        }
        public Int32 GetValYear()
        {
            return valYear;
        }
        public Int32 GetValMonth()
        {
            return valMonth;
        }
    }
    public class CustomerDataTable
    {
        private Int32 srno;
        private Int32 rpmMin;
        private Int32 rpmMax;
        private Int32 oilTemp;
        private Double kVal;
        private Double hsuPer;

        public CustomerDataTable()
        {
            this.srno = 0;
            this.rpmMin = 0;
            this.rpmMax = 0;
            this.oilTemp = 0;
            this.kVal = 0;
            this.hsuPer = 0;
        }
        public CustomerDataTable(Int32 srno,
                                Int32 rpmMin,
                                Int32 rpmMax,
                                Int32 oilTemp,
                                Double kVal,
                                Double hsuPer)
        {
            this.srno = srno;
            this.rpmMin = rpmMin;
            this.rpmMax = rpmMax;
            this.oilTemp = oilTemp;
            this.kVal = kVal;
            this.hsuPer = hsuPer;
        }

        public void AddCustomerDataTable(Int32 srno,
                                Int32 rpmMin,
                                Int32 rpmMax,
                                Int32 oilTemp,
                                Double kVal,
                                Double hsuPer)
        {
            this.srno = srno;
            this.rpmMin = rpmMin;
            this.rpmMax = rpmMax;
            this.oilTemp = oilTemp;
            this.kVal = kVal;
            this.hsuPer = hsuPer;
        }

        public Int32 SrNo
        {
            get
            {
                return srno;
            }
        }
        public Int32 RPMMin
        {
            get
            {
                return rpmMin;
            }
        }
        public Int32 RPMMax
        {
            get
            {
                return rpmMax;
            }
        }
        public Int32 OILTemp
        {
            get
            {
                return oilTemp;
            }
        }
        public Double KVal
        {
            get
            {
                return kVal;
            }
        }
        public Double HSUPer
        {
            get
            {
                return hsuPer;
            }
        }
    }

    public class CustomerData
    {
        private String vehNo, category, vehMake, result;
        private String vehModel, fuelType, validUpto, regYear, image;
        private DateTime dateOn, time;
#if true
        public CustomerData()
        {
            this.vehNo = "";
            this.category = "";
            this.dateOn = DateTime.Today;
            this.vehMake = "";
            this.vehModel = "";
            this.fuelType = "";
            this.time = DateTime.Today;
            this.validUpto = "";
            this.regYear = "";
            this.result = "";
            this.image = "";
        }
#else
        public CustomerData()
        {
            this.vehNo = "CG04JC6539";
            this.category = "3 W";
            this.dateOn = DateTime.Now;
            this.vehMake = "PIAGGIO";
            this.vehModel = "AUTO";
            this.fuelType = "DIESEL";
            this.time = DateTime.Now;
            this.validUpto = DateTime.Today.AddMonths(6).ToString("dd/MM/yyyy");
            this.regYear = "2012";
            this.result = "PASS";
            this.image = "E:/tmp/UK-Car-Number-Plate.jpg";
        }
#endif

        public CustomerData(String vehNo,
                            String category,
                            DateTime dateOn,
                            String vehMake,
                            String vehModel,
                            String fuelType,
                            DateTime time,
                            String validUpto,
                            String regYear,
                            String result,
                            String image)
        {
            this.vehNo = vehNo;
            this.category = category;
            this.dateOn = dateOn;
            this.vehMake = vehMake;
            this.vehModel = vehModel;
            this.fuelType = fuelType;
            this.time = time;
            this.validUpto = validUpto;
            this.regYear = regYear;
            this.result = result;
            this.image = image;
        }
        public void AddCustomerData(String vehNo,
                                String category,
                                String vehMake,
                                String vehModel,
                                String fuelType,
                                String validUpto,
                                String regYear,
                                String result,
                                String image)
        {
            this.vehNo = vehNo;
            this.category = category;
            this.dateOn = DateTime.Now;
            this.vehMake = vehMake;
            this.vehModel = vehModel;
            this.fuelType = fuelType;
            this.time = DateTime.Now;
            this.validUpto = validUpto;
            this.regYear = regYear;
            this.result = result;
            this.image = image;
        }

        public String VehNo
        {
            get
            {
                return vehNo;
            }
        }
        public String Category
        {
            get
            {
                return category;
            }
        }
        public String VehMake
        {
            get
            {
                return vehMake;
            }
        }
        public String VehModel
        {
            get
            {
                return vehModel;
            }
        }
        public String FuelType
        {
            get
            {
                return fuelType;
            }
        }
        public String ValidUpto
        {
            get
            {
                return validUpto;
            }
        }
        public String DateOn
        {
            get
            {
                return dateOn.ToString("dd/MM/yyyy");
            }
        }
        public String Time
        {
            get
            {
                return time.ToString("h:mm:ss tt");
            }
        }
        public String Result
        {
            get
            {
                return result;
            }
        }
        public String Image
        {
            get
            {
                return image;
            }
        }
        public String RegYear
        {
            get
            {
                return regYear;
            }
        }
    }
    public class CustomerDataTablePetrol
    {
        private String co, hc;
        public CustomerDataTablePetrol()
        {
            co = "";
            hc = "";
        }
        public CustomerDataTablePetrol(String co, String hc)
        {
            this.co = co;
            this.hc = hc;
        }
        public void AddCustomerDataTablePetrol(String co, String hc)
        {
            this.co = co;
            this.hc = hc;
        }
        public String CO
        {
            get
            {
                return co;
            }
        }
        public String HC
        {
            get
            {
                return hc;
            }
        }
    }
}