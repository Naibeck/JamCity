using Data;
using Data.Sources;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Tests.Data
{
    public class SalaryRecordRepositoryTests
    {

        [Test]
        public void FetchNullSalaryIfNoRecordIsRegistered()
        {
            // Given
            var salaryDataSource = Substitute.For<ISalaryRecordDataSource>();
            salaryDataSource.FetchSalaries().Returns(new SalaryRecord[] {});
            var ceo = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.CEO, seniority: Seniority.Senior);
            ISalaryRepository salaryRepository = new SalaryRecordRepositoryImpl(dataSource: salaryDataSource);
        
            // When
            var result = salaryRepository.GetSalaryRecord(ceo);
        
            // Then
            Assert.IsNull(result);
            salaryDataSource.Received(1).FetchSalaries();
        }
    }
}
