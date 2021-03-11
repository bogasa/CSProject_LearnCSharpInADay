namespace CSProject
{
    class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;

        public Admin(string name) : base(name, adminHourlyRate) { }

        public float Overtime { get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
                Overtime = overtimeRate * (HoursWorked - 160);
        }
        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nadminHourlyRate = " + adminHourlyRate + "\nHoursWorked" + HoursWorked + "\nBasicPay = " +
                   BasicPay + "\nOvertime = " + Overtime + "\nTotalPay = " + TotalPay;
        }
    }
}