using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CSProject
{
    class PaySlip
    {
        private int month;
        private int year;

        private enum MonthsOfYear { Jan = 1, Feb = 2, Mar = 3, Apr = 4, May = 5, Jun = 6, Jul = 7, Aug = 8, Sep = 9, Oct = 10, Nov = 11, Dec = 12 }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach (var f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                using var sw = new StreamWriter(path);
                sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                sw.WriteLine("=========================");
                sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                sw.WriteLine("");
                sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                if (f.GetType() == typeof(Manager))
                    sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                else if (f.GetType() == typeof(Admin))
                    sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);
                sw.WriteLine("");
                sw.WriteLine("========================");
                sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                sw.WriteLine("========================");
                sw.Close();
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            //staff that worked less than 10h in a month
            var result =
                from f in myStaff
                where f.HoursWorked < 10
                orderby f.NameOfStaff
                select new {f.NameOfStaff, f.HoursWorked};

            
                string path = "summary.txt";
                using var sw = new StreamWriter(path);
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var f in result)
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);
                sw.Close();
        }

        public override string ToString()
        {
            return "\nmonth = " + month + "\nyear = " + year;
        }
    }
}