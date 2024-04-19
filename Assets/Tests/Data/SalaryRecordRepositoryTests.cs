using Data;
using NUnit.Framework;
using Tests.Mocks.Sources;

namespace Tests.Data
{
    public class SalaryRecordRepositoryTests
    {

        [Test]
        public void FetchNullSalaryIfNoRecordIsRegistered()
        {
            // Given
            var salaryDataSource = new MockNonWorkerSalaryRecordSource();
            var ceo = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.CEO, seniority: Seniority.Senior);
            ISalaryRepository salaryRepository = new SalaryRecordRepositoryImpl(dataSource: salaryDataSource);
        
            // When
            var result = salaryRepository.GetSalaryRecord(ceo);
        
            // Then
            Assert.IsNull(result); 
        }
    }
}
