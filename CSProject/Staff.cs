namespace CSProject
{
    class Staff
    {
        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        private float hourlyRate;
        private int hWorked;
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }   
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get { return hWorked; }
            set
            {
                if (HoursWorked > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }

        public virtual void CalculatePay()
        {
            //calculate pay of each staff
        }
    }
}