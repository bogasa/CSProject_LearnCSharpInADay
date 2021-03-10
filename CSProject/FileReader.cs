using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace CSProject
{
    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            var result = new string[2];
            var path = "staff.txt";
            string[] separator = {", "};
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (Equals(!sr.EndOfStream))
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        if (result[1] == "Manager")
                        {
                            myStaff.Add(new Manager(result[0]));
                        }
                        else if (result[1] == "Admin")
                        {
                            myStaff.Add((new Manager(result[0])));
                        }
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }

            return myStaff;
        }

    }
}