using System.Linq;
using Data.Sources;
using JetBrains.Annotations;

namespace Data
{
    public class SalaryRecordRepositoryImpl : ISalaryRepository
    {

        private readonly ISalaryRecordDataSource _salaryRecordDataSource;
        
        public SalaryRecordRepositoryImpl(ISalaryRecordDataSource dataSource)
        {
            _salaryRecordDataSource = dataSource;
        }

        [CanBeNull]
        public SalaryRecord GetSalaryRecord(Worker worker) => _salaryRecordDataSource.FetchSalaries()
            .FirstOrDefault(record => record.WorkerId.Equals(worker.GetHashCode()));
    }
}