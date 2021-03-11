﻿using System;

namespace CSProject
{
    class Staff
    {
       private float hourlyRate;
        private int hWorked;
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }   
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            //calculate pay of each staff
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nhWorked = " + hWorked + "\nhourlyRate = " + hourlyRate + "\nBasicPay = " +
                   BasicPay + "\nTotalPay = " + TotalPay;
        }
    }
}