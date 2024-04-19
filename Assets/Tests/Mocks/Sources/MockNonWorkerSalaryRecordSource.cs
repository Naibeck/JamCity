using System.Collections.Generic;
using Data;
using Data.Sources;

namespace Tests.Mocks.Sources
{
    public class MockNonWorkerSalaryRecordSource : ISalaryRecordDataSource
    {
        public IEnumerable<SalaryRecord> FetchSalaries()
        {
            return new SalaryRecord[] { };
        }
    }
}