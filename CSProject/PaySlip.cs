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

        enum MonthOfYear
        {
            JAN = 1, FEB = 2, MAR = 3, APR = 4, MAY = 5, JUN = 6, JUL = 7, AUG = 8, SEP = 9, OCT = 10, NOV = 11, DEC = 12
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            var path = "";
            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                using var sw = new StreamWriter(path);
                sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthOfYear)month, year);
                sw.WriteLine("=========================");
                sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                sw.WriteLine("Name of Staff: {0}", f.HoursWorked);
                sw.WriteLine("");
                sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                if (f.GetType() == typeof(Manager))
                {
                    sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                }
                else
                {
                    sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);
                }
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
                from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new {staff.NameOfStaff, staff.HoursWorked};

            
                var path = "summary.txt";
                using var sw = new StreamWriter(path);
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var r in result)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", r.NameOfStaff, r.HoursWorked);
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", r.NameOfStaff, r.HoursWorked);
                }
                sw.Close();
        }

        public override string ToString()
        {
            return "\nmonth = " + month + "\nyear = " + year;
        }
    }
}