using Data;
using NUnit.Framework;
using Tests.Mocks.Sources;

namespace Tests.Data
{
    public class WorkersRepositoryTests
    {

        [Test]
        public void EmployersShouldBeLoadedAsEmpty()
        {
            // Given
            var emptyWorkers = new MockEmptyWorkersDataSource();
            IWorkersRepository workersRepository = new WorkersRepositoryImpl(dataSource: emptyWorkers);
        
            // When
            var result = workersRepository.LoadWorkers();
        
            // Then
            Assert.IsEmpty(result); 
            Assert.IsTrue(emptyWorkers.Fetched); // Look for a mock library for unity or C# that could use the same behavior than verify times as mockk or mockito in Java/Kotlin
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
            var workers = new MockWorkersDataSource(workers: expectedWorkers);
            IWorkersRepository workersRepository = new WorkersRepositoryImpl(dataSource: workers);
            
            // When
            var result = workersRepository.LoadWorkers();
        
            // Then
            Assert.IsNotEmpty(result);
            Assert.AreEqual(expectedWorkers, result);
            Assert.IsTrue(workers.Fetched);
        }
        
        [Test]
        public void EmployersShouldBeEmptyIfAnErrorHappens()
        {
            // Given
            var workers = new MockCrashWorkersDataSource();
            IWorkersRepository workersRepository = new WorkersRepositoryImpl(dataSource: workers);
        
            // When
            var result = workersRepository.LoadWorkers();
        
            // Then
            Assert.IsEmpty(result);
            Assert.IsTrue(workers.Fetched);
        }
    }
}
