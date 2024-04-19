using System.Collections.Generic;
using Data;
using Data.Sources;

namespace Tests.Mocks.Sources
{
    public class MockWorkerSalaryRecordSource : ISalaryRecordDataSource
    {
        private static readonly Worker Ceo = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.CEO,
            seniority: Seniority.Senior);

        public IEnumerable<SalaryRecord> FetchSalaries()
        {
            return new SalaryRecord[]
            {
                new SalaryRecord(workerId: Ceo.GetHashCode(), salary: 40_000),
            };
        }
    }
}