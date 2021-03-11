namespace CSProject
{
    class Manager : Staff
    {
        private const float managerHourlyRate = 50f;

        public Manager(string name) : base(name, managerHourlyRate) { }

        public int Allowance { get; private set; }

        public override void CalculatePay() 
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nmanagerHourlyRate" + managerHourlyRate + "\nHoursWorked" + HoursWorked + "\nBasicPay = " +
                   BasicPay + "\nAllowance = " + Allowance + "\nTotalPay = " + TotalPay;
        }
    }
}