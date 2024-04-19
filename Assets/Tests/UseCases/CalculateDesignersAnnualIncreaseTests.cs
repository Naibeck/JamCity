using System;
using Data;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using UseCases;

namespace Tests.UseCases
{
    public class CalculateDesignersAnnualIncreaseTests
    {

        [Test]
        public void CalculateDesignersSalaryIncreaseForNonRecordAvailable()
        {
            
            // Given
            const int expectedSrSalary = 2_140;
            const int expectedSsrSalary = 832;
            
            const int expectedSrIncrease = 140;
            const int expectedSsrIncrease = 32;

            var srArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Design,
                seniority: Seniority.Senior);
            var ssrArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Design,
                seniority: Seniority.Junior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(Arg.Any<Worker>()).ReturnsNull();
            
            var artistCalculation = new CalculateDesignersAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srArtist); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrArtist); 
            
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
            const double expectedSrSalary = 2_289.8;
            const double expectedSsrSalary = 865.28;
            
            const double expectedSrIncrease = 149.8;
            const double expectedSsrIncrease = 33.28;

            var srArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Design,
                seniority: Seniority.Senior);
            var ssrArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Design,
                seniority: Seniority.Junior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(srArtist).Returns(new SalaryRecord(workerId: srArtist.GetHashCode(), salary: 2_140));
            salaryRepository.GetSalaryRecord(ssrArtist).Returns(new SalaryRecord(workerId: ssrArtist.GetHashCode(), salary: 832));
            
            var artistCalculation = new CalculateDesignersAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srArtist); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrArtist); 
            
            // Then
            Assert.AreEqual(expectedSrSalary, srUpdatedSalaryAmount);
            Assert.AreEqual(expectedSrIncrease, srIncreaseAmount);
            
            Assert.AreEqual(expectedSsrSalary, ssrUpdatedSalaryAmount);
            Assert.AreEqual(expectedSsrIncrease, ssrIncreaseAmount);
            
            salaryRepository.Received(2).GetSalaryRecord(Arg.Any<Worker>());
        }
    }
}
