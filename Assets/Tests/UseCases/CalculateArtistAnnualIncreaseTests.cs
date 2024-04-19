using System;
using Data;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using UseCases;

namespace Tests.UseCases
{
    public class CalculateArtistAnnualIncreaseTests
    {

        [Test]
        public void CalculateArtistSalaryIncreaseForNonRecordAvailable()
        {
            
            // Given
            const int expectedSrSalary = 2_100;
            const int expectedSsrSalary = 1230;
            
            const int expectedSrIncrease = 100;
            const int expectedSsrIncrease = 30;

            var srArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Artist,
                seniority: Seniority.Senior);
            var ssrArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Artist,
                seniority: Seniority.SemiSenior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(Arg.Any<Worker>()).ReturnsNull();
            
            var artistCalculation = new CalculateArtistAnnualIncrease(salaryRepository: salaryRepository);
            
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
        public void CalculateArtistSalaryIncreaseForAvailableSalaryRecord()
        {
            
            // Given
            const double expectedSrSalary = 2_205;
            const double expectedSsrSalary = 1260.75;
            
            const double expectedSrIncrease = 105;
            const double expectedSsrIncrease = 30.75;

            var srArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Artist,
                seniority: Seniority.Senior);
            var ssrArtist = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Artist,
                seniority: Seniority.SemiSenior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(srArtist).Returns(new SalaryRecord(workerId: srArtist.GetHashCode(), salary: 2_100));
            salaryRepository.GetSalaryRecord(ssrArtist).Returns(new SalaryRecord(workerId: ssrArtist.GetHashCode(), salary: 1_230));
            
            var artistCalculation = new CalculateArtistAnnualIncrease(salaryRepository: salaryRepository);
            
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
