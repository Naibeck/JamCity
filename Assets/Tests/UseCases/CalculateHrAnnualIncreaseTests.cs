using System;
using Data;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using UseCases;

namespace Tests.UseCases
{
    public class CalculateHrAnnualIncreaseTests
    {

        [Test]
        public void CalculateHrSalaryIncreaseForNonRecordAvailable()
        {
            
            // Given
            const int expectedSrSalary = 1_575;
            const int expectedSsrSalary = 1_020;
            const double expectedJrSalary = 502.5;
            
            const int expectedSrIncrease = 75;
            const int expectedSsrIncrease = 20;
            const double expectedJrIncrease = 2.5;

            var srHr = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.HR, seniority: Seniority.Senior);
            var ssrHr = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.HR, seniority: Seniority.SemiSenior);
            var jrHr = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.HR, seniority: Seniority.Junior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(Arg.Any<Worker>()).ReturnsNull();
            
            var artistCalculation = new CalculateHrAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srHr); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrHr); 
            var (jrUpdatedSalaryAmount, jrIncreaseAmount) = artistCalculation.Calculate(worker: jrHr); 
            
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
        public void CalculateHrSalaryIncreaseForAvailableSalaryRecord()
        {
            
            // Given
            const double expectedSrSalary = 1_653.75;
            const double expectedSsrSalary = 1_040.4;
            const double expectedJrSalary = 505.0;
            
            const double expectedSrIncrease = 78.75;
            const double expectedSsrIncrease = 20.4;
            const double expectedJrIncrease = 2.5;

            var srEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.HR, seniority: Seniority.Senior);
            var ssrEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.HR, seniority: Seniority.SemiSenior);
            var jrEngineer = new Worker(firstName: "Fred", lastName: "Fredburger", position: Position.HR, seniority: Seniority.Junior);
            
            var salaryRepository = Substitute.For<ISalaryRepository>();
            salaryRepository.GetSalaryRecord(srEngineer).Returns(new SalaryRecord(workerId: srEngineer.GetHashCode(), salary: 1_575));
            salaryRepository.GetSalaryRecord(ssrEngineer).Returns(new SalaryRecord(workerId: ssrEngineer.GetHashCode(), salary: 1_020));
            salaryRepository.GetSalaryRecord(jrEngineer).Returns(new SalaryRecord(workerId: jrEngineer.GetHashCode(), salary: 502.5));
            
            var artistCalculation = new CalculateHrAnnualIncrease(salaryRepository: salaryRepository);
            
            // When
            var (srUpdatedSalaryAmount, srIncreaseAmount) = artistCalculation.Calculate(worker: srEngineer); 
            var (ssrUpdatedSalaryAmount, ssrIncreaseAmount) = artistCalculation.Calculate(worker: ssrEngineer); 
            var (jrUpdatedSalaryAmount, jrIncreaseAmount) = artistCalculation.Calculate(worker: jrEngineer); 
            
            // Then
            Assert.AreEqual(expectedSrSalary, srUpdatedSalaryAmount);
            Assert.AreEqual(expectedSrIncrease, srIncreaseAmount);
            
            Assert.AreEqual(expectedSsrSalary, ssrUpdatedSalaryAmount);
            Assert.AreEqual(expectedSsrIncrease, ssrIncreaseAmount);

            Assert.IsTrue(Math.Abs(expectedJrSalary - jrUpdatedSalaryAmount) <= 0.01d);
            Assert.IsTrue(Math.Abs(expectedJrIncrease - jrIncreaseAmount) <= 0.01d);
            
            salaryRepository.Received(3).GetSalaryRecord(Arg.Any<Worker>());
        }
    }
}
