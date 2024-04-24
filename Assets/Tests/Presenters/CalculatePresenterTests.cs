using System;
using Data;
using NSubstitute;
using NUnit.Framework;
using Presenters;
using UseCases;

namespace Tests.Presenters
{
    public class CalculatePresenterTests
    {
        [Test]
        public void CalculateWorkersTotalSalaryForDepartment()
        {
            // Given
            const string expected = "HR Workers: 2 total salary: 2000\n" +
                                    "Engineering Workers: 2 total salary: 2000\n" +
                                    "Artist Workers: 4 total salary: 4000\n" +
                                    "Design Workers: 2 total salary: 2000\n" +
                                    "PM Workers: 1 total salary: 1000\n" +
                                    "CEO Workers: 1 total salary: 1000";
            var workerRepository = Substitute.For<IWorkersRepository>();
            var annualIncrease = Substitute.For<ICalculateAnnualIncrease>();

            workerRepository.LoadWorkers(sort: true).Returns(new[]
            {
                new Worker(
                    firstName: "1",
                    lastName: "",
                    position: Position.HR,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "2",
                    lastName: "",
                    position: Position.HR,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "3",
                    lastName: "",
                    position: Position.Engineering,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "4",
                    lastName: "",
                    position: Position.Engineering,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "5",
                    lastName: "",
                    position: Position.PM,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "6",
                    lastName: "",
                    position: Position.Artist,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "7",
                    lastName: "",
                    position: Position.Artist,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "8",
                    lastName: "",
                    position: Position.Artist,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "9",
                    lastName: "",
                    position: Position.Artist,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "10",
                    lastName: "",
                    position: Position.Design,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "11",
                    lastName: "",
                    position: Position.Design,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "12",
                    lastName: "",
                    position: Position.CEO,
                    seniority: Seniority.Senior
                ),
            });
            
            annualIncrease.Calculate(Arg.Any<Worker>()).Returns(new Tuple<double, double>(1000, 20));
            
            var presenter = new CalculatePresenterImpl(
                repository: workerRepository,
                hrIncrease: annualIncrease,
                engineersIncrease: annualIncrease,
                artistIncrease: annualIncrease,
                designIncrease: annualIncrease,
                pmsIncrease: annualIncrease,
                ceoIncrease: annualIncrease
            );
            
            // When
            var result = presenter.OnCalculateSalary();
            
            // Then
            Assert.AreEqual(expected, result);
        }
    }
}