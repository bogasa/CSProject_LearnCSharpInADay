using System;
using System.Collections.Generic;

namespace CSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStaff = new List<Staff>();
            var fr = new FileReader();
            var month = 0;
            var year = 0;

            while (year == 0)
            {
                Console.Write("\nPlease enter the year: ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Not a valid year!");
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month: ");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Month must be between 1 and 12!");
                        month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Not a valid month!");
                }
            }

            myStaff = fr.ReadFile();

            for (var i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter hours worked for {0}: ", myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            var ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read();
        }
    }
}
