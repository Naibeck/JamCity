using JetBrains.Annotations;

namespace Data
{
    public interface ISalaryRepository
    {
        [CanBeNull] SalaryRecord GetSalaryRecord(Worker worker);
    }
}