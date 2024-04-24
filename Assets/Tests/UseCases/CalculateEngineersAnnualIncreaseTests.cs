using System;
using Data;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using UseCases;

namespace Tests.UseCases
{
    public class CalculateEngineersAnnualIncreaseTests
    {

        [Test]
        public void CalculateEngineersSalaryIncreaseForNonRecordAvailable()
        {
            
            // Given
            const int expectedSrSalary = 5_500;
            const int expectedSsrSalary = 3_210;
            const int expectedJrSalary = 1_575;
            
            const int expectedSrIncrease = 500;
            const int expectedSsrIncrease = 210;
            const int expectedJrIncrease = 75;

            var srEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Engineering, seniority: Seniority.Senior);
            var ssrEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Engineering, seniority: Seniority.SemiSenior);
            var jrEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Engineering, seniority: Seniority.Junior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(Arg.Any<Worker>()).ReturnsNull();
            
            var artistCalculation = new CalculateEngineersAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srEngineer); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrEngineer); 
            var (jrUpdatedSalaryAmount, jrIncreaseAmount) = artistCalculation.Calculate(worker: jrEngineer); 
            
            // Then
            Assert.AreEqual(expectedSrSalary, srUpdatedSalaryAmount);
            Assert.AreEqual(expectedSrIncrease, srIncreaseAmount);
            
            Assert.AreEqual(expectedSsrSalary, ssrUpdatedSalaryAmount);
            Assert.AreEqual(expectedSsrIncrease, ssrIncreaseAmount);

            Assert.AreEqual(expectedJrSalary, jrUpdatedSalaryAmount);
            Assert.AreEqual(expectedJrIncrease, jrIncreaseAmount);
            
            salaryRepository.Received(3).GetSalaryRecord(Arg.Any<Worker>());
        }
        
        [Test]
        public void CalculateEngineersSalaryIncreaseForAvailableSalaryRecord()
        {
            
            // Given
            const int expectedSrSalary = 6_050;
            const double expectedSsrSalary = 3_434.7;
            const double expectedJrSalary = 1_653.75;
            
            const int expectedSrIncrease = 550;
            const double expectedSsrIncrease = 224.7;
            const double expectedJrIncrease = 78.75;

            var srEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Engineering, seniority: Seniority.Senior);
            var ssrEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Engineering, seniority: Seniority.SemiSenior);
            var jrEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.Engineering, seniority: Seniority.Junior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(srEngineer).Returns(new SalaryRecord(workerId: srEngineer.GetHashCode(), salary: 5_500));
            salaryRepository.GetSalaryRecord(ssrEngineer).Returns(new SalaryRecord(workerId: ssrEngineer.GetHashCode(), salary: 3_210));
            salaryRepository.GetSalaryRecord(jrEngineer).Returns(new SalaryRecord(workerId: jrEngineer.GetHashCode(), salary: 1_575));
            
            var artistCalculation = new CalculateEngineersAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srEngineer); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrEngineer); 
            var (jrUpdatedSalaryAmount, jrIncreaseAmount) = artistCalculation.Calculate(worker: jrEngineer); 
            
            // Then
            Assert.AreEqual(expectedSrSalary, srUpdatedSalaryAmount);
            Assert.AreEqual(expectedSrIncrease, srIncreaseAmount);
            
            Assert.AreEqual(expectedSsrSalary, ssrUpdatedSalaryAmount);
            Assert.AreEqual(expectedSsrIncrease, ssrIncreaseAmount);

            Assert.AreEqual(expectedJrSalary, jrUpdatedSalaryAmount);
            Assert.AreEqual(expectedJrIncrease, jrIncreaseAmount);
            
            salaryRepository.Received(3).GetSalaryRecord(Arg.Any<Worker>());
        }
    }
}
