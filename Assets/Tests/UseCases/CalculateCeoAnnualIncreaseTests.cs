using System;
using Data;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
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
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(Arg.Any<Worker>()).ReturnsNull();
            
            var ceoCalculation = new CalculateCeoAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (updatedSalaryAmount, increaseAmount) = ceoCalculation.Calculate(worker: ceo); 
            
            // Then
            Assert.AreEqual(expectedSalary, updatedSalaryAmount);
            Assert.AreEqual(expectedIncrease, increaseAmount);
            salaryRepository.Received(1).GetSalaryRecord(Arg.Any<Worker>());
        }
        
        [Test]
        public void CalculateCeoSalaryIncreaseForAvailableSalaryRecord()
        {
            
            // Given
            const int expectedSalary = 80_000;
            const int expectedIncrease = 40_000;
            
            var ceo = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.CEO,
                seniority: Seniority.Senior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(Arg.Any<Worker>()).Returns(new SalaryRecord(workerId: ceo.GetHashCode(), salary: 40_000));
            
            var ceoCalculation = new CalculateCeoAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (updatedSalaryAmount, increaseAmount) = ceoCalculation.Calculate(worker: ceo); 
            
            // Then
            Assert.AreEqual(expectedSalary, updatedSalaryAmount);
            Assert.AreEqual(expectedIncrease, increaseAmount);
            salaryRepository.Received(1).GetSalaryRecord(Arg.Any<Worker>());
        }
    }
}
