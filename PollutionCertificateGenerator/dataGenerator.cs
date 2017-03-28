using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollutionCertificateGenerator
{
    public class dataGenerator
    {
        Random random;
        private CustomerDataTableList dataTableList;
        double avgKval, avgHsuPer;
        struct range
        {
            public int min, max;
        }
        public dataGenerator()
        {
            random = new Random();
        }
        public CustomerDataTableList GetDataTableList()
        {
            //GenerateData();
            return dataTableList;
        }
        public double AvgKVAL
        {
            get
            {
                return avgKval;
            }
        }
        public double AvgHSUPer
        {
            get
            {
                return avgHsuPer;
            }
        }
        private void CalMinRPMRange(ref range minRPM)
        {
            int rpm =(int)(random.Next(600, 900)/100.0 + 0.5)*100;
            minRPM.min = rpm;
            minRPM.max = rpm + 100;
        }
        private void CalMaxRPMRange(range minRPM, ref range maxRPM)
        {
            switch(minRPM.min)
            {
                case 600:
                    maxRPM.min = 2000;
                    maxRPM.max = 3000;
                    break;
                case 700:
                    maxRPM.min = 2500;
                    maxRPM.max = 3500;
                    break;
                case 800:
                    maxRPM.min = 3000;
                    maxRPM.max = 4000;
                    break;
                case 900:
                    maxRPM.min = 4000;
                    maxRPM.max = 5000;
                    break;
            }
        }
        private double CalKMPGenerator()
        {
            double num = random.Next(1, 2);
            num = num * 100 + random.Next(0, 99);
            num = num / 100.0;
            return num;
        }
        private double CalHSUPerGenerator(range hsuPerRange)
        {
            double num = random.Next(hsuPerRange.min, hsuPerRange.max);
            num = num * 10 + random.Next(0, 10);
            num = num / 10.0;
            return num;
        }
        private void CalMaxTempGenerator(ref range tempRange)
        {
            int minTemp = ((int)(random.Next(60,99)/10))*10;
            tempRange.min = minTemp;
            tempRange.max = minTemp+10;            
        }
        public void GenerateData(bool isFail)
        {
            int numEntries, i;
            int minRPM, maxRPM, temp;
            double kmp, hsuPer;
            range minRPMRange = new range();
            range maxRPMRange = new range();
            range hsuRange = new range();
            range tempRange = new range();
            dataTableList = new CustomerDataTableList();
            if (isFail == false)
            {
                hsuRange.min = 50;
                hsuRange.max = 65;
            }
            else
            {
                hsuRange.min = 65;
                hsuRange.max = 70;
            }

            numEntries = random.Next(4, 6);
            CalMinRPMRange(ref minRPMRange);
            CalMaxRPMRange(minRPMRange, ref maxRPMRange);
            CalMaxTempGenerator(ref tempRange);
            avgKval = 0;
            avgHsuPer = 0;
            for (i = 0; i < numEntries; i++)
            {
                minRPM = random.Next(minRPMRange.min, minRPMRange.max);
                maxRPM = random.Next(maxRPMRange.min, maxRPMRange.max);
                hsuPer = CalHSUPerGenerator(hsuRange);
                temp = random.Next(tempRange.min, tempRange.max);
                kmp = CalKMPGenerator();
                avgKval += kmp;
                avgHsuPer += hsuPer;
                dataTableList.AddData(new CustomerDataTable(i + 1, minRPM, maxRPM, temp, kmp, hsuPer));
            }
            avgKval /= numEntries;
            avgHsuPer /= numEntries;
        }
    }
}
