namespace Data
{
    public class SalaryRecord
    {
        public int WorkerId { get; }
        public double Salary { get; }

        public SalaryRecord(int workerId, double salary)
        {
            WorkerId = workerId;
            Salary = salary;
        }
    }
}