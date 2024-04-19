using System;
using Data;
using Data.Sources;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Tests.Data
{
    public class WorkersRepositoryTests
    {

        [Test]
        public void EmployersShouldBeLoadedAsEmpty()
        {
            // Given
            var emptyWorkers = Substitute.For<IWorkerDataSource>();
            emptyWorkers.FetchWorkers().Returns(new Worker[] { });
            IWorkersRepository workersRepository = new WorkersRepositoryImpl(dataSource: emptyWorkers);
        
            // When
            var result = workersRepository.LoadWorkers();
        
            // Then
            Assert.IsEmpty(result); 
            emptyWorkers.Received(1).FetchWorkers();
        }
        
        [Test]
        public void EmployersShouldBeLoadedIfAnyIsAvailable()
        {
            // Given
            var expectedWorkers =  new []
            {
                new Worker(
                    firstName: "",
                    lastName: "",
                    position: Position.CEO,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "",
                    lastName: "",
                    position: Position.Artist,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "",
                    lastName: "",
                    position: Position.Design,
                    seniority: Seniority.Senior
                ),
                new Worker(
                    firstName: "",
                    lastName: "",
                    position: Position.Engineering,
                    seniority: Seniority.Senior
                ),
            };
            var workers = Substitute.For<IWorkerDataSource>();
            workers.FetchWorkers().Returns(expectedWorkers);
            IWorkersRepository workersRepository = new WorkersRepositoryImpl(dataSource: workers);
            
            // When
            var result = workersRepository.LoadWorkers();
        
            // Then
            Assert.IsNotEmpty(result);
            Assert.AreEqual(expectedWorkers, result);
            workers.Received(1).FetchWorkers();
        }
        
        [Test]
        public void EmployersShouldBeEmptyIfAnErrorHappens()
        {
            // Given
            var workers = Substitute.For<IWorkerDataSource>();
            workers.FetchWorkers().Throws(new Exception("Test crash"));
            IWorkersRepository workersRepository = new WorkersRepositoryImpl(dataSource: workers);
        
            // When
            var result = workersRepository.LoadWorkers();
        
            // Then
            Assert.IsEmpty(result);
            workers.Received(1).FetchWorkers();
        }
    }
}
