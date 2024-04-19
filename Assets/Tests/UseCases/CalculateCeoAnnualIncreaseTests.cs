using System;
using Data;
using NUnit.Framework;
using Tests.Mocks.Sources;
using UseCases;

namespace Tests.UseCases
{
    public class CalculateCeoAnnualIncreaseTests
    {

        [Test]
        public void CalculateCeoSalaryIncreaseForNonRecordAvailable()
        {
            
            // Given
            const int expectedSalary = 40_000;
            const int expectedIncrease = 20_000;
            
            var ceo = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.CEO,
                seniority: Seniority.Senior);
            var ceoCalculation = new CalculateCeoAnnualIncrease(salaryRepository: new SalaryRecordRepositoryImpl(new MockNonWorkerSalaryRecordSource()));
            
            // When
            var (updatedSalaryAmount, increaseAmount) = ceoCalculation.Calculate(worker: ceo); 
            
            // Then
            Assert.AreEqual(expectedSalary, updatedSalaryAmount);
            Assert.AreEqual(expectedIncrease, increaseAmount);
        }
        
        [Test]
        public void CalculateCeoSalaryIncreaseForAvailableSalaryRecord()
        {
            
            // Given
            const int expectedSalary = 80_000;
            const int expectedIncrease = 40_000;
            
            var ceo = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.CEO,
                seniority: Seniority.Senior);
            var ceoCalculation = new CalculateCeoAnnualIncrease(salaryRepository: new SalaryRecordRepositoryImpl(new MockWorkerSalaryRecordSource()));
            
            // When
            var (updatedSalaryAmount, increaseAmount) = ceoCalculation.Calculate(worker: ceo); 
            
            // Then
            Assert.AreEqual(expectedSalary, updatedSalaryAmount);
            Assert.AreEqual(expectedIncrease, increaseAmount);
        }
    }
}
