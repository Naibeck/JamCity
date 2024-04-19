namespace Data
{
    public interface ISalaryRepository
    {
        SalaryRecord GetSalaryRecord(Worker worker);
    }
}