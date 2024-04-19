using System;
using Data;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using UseCases;

namespace Tests.UseCases
{
    public class CalculatePmsAnnualIncreaseTests
    {

        [Test]
        public void CalculateDesignersSalaryIncreaseForNonRecordAvailable()
        {
            
            // Given
            const int expectedSrSalary = 4_400;
            const int expectedSsrSalary = 2_520;
            
            const int expectedSrIncrease = 400;
            const int expectedSsrIncrease = 120;

            var srPm = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.PM,
                seniority: Seniority.Senior);
            var ssrPm = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.PM,
                seniority: Seniority.SemiSenior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(Arg.Any<Worker>()).ReturnsNull();
            
            var artistCalculation = new CalculatePmsAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srPm); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrPm); 
            
            // Then
            Assert.AreEqual(expectedSrSalary, srUpdatedSalaryAmount);
            Assert.AreEqual(expectedSrIncrease, srIncreaseAmount);
            
            Assert.AreEqual(expectedSsrSalary, ssrUpdatedSalaryAmount);
            Assert.AreEqual(expectedSsrIncrease, ssrIncreaseAmount);
            
            salaryRepository.Received(2).GetSalaryRecord(Arg.Any<Worker>());
        }
        
        [Test]
        public void CalculateDesignersSalaryIncreaseForAvailableSalaryRecord()
        {
            
            // Given
            const double expectedSrSalary = 4_840;
            const double expectedSsrSalary = 2_646;
            
            const double expectedSrIncrease = 440;
            const double expectedSsrIncrease = 126;

            var srPm = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.PM,
                seniority: Seniority.Senior);
            var ssrPm = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.PM,
                seniority: Seniority.SemiSenior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(srPm).Returns(new SalaryRecord(workerId: srPm.GetHashCode(), salary: 4_400));
            salaryRepository.GetSalaryRecord(ssrPm).Returns(new SalaryRecord(workerId: ssrPm.GetHashCode(), salary: 2_520));
            
            var artistCalculation = new CalculatePmsAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srPm); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrPm); 
            
            // Then
            Assert.AreEqual(expectedSrSalary, srUpdatedSalaryAmount);
            Assert.AreEqual(expectedSrIncrease, srIncreaseAmount);
            
            Assert.AreEqual(expectedSsrSalary, ssrUpdatedSalaryAmount);
            Assert.AreEqual(expectedSsrIncrease, ssrIncreaseAmount);
            
            salaryRepository.Received(2).GetSalaryRecord(Arg.Any<Worker>());
        }
    }
}
