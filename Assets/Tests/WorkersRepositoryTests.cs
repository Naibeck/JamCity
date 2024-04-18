using Data;
using NUnit.Framework;
using Tests.Mocks.Sources;

namespace Tests
{
    public class WorkersRepositoryTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EmployersShouldBeLoadedAsEmpty()
        {
            // Given
            var emptyWorkers = new MockEmptyDataSource();
            WorkersRepository workersRepository = new WorkersRepositoryImpl(emptyWorkers);
        
            // When
            var result = workersRepository.LoadWorkers();
        
            // Then
            Assert.IsEmpty(result); // Look for a mock library for unity or C# that could use the same behavior than verify times as mockk or mockito in Java/Kotlin
            Assert.IsTrue(emptyWorkers.Fetched);
        }
    }
}
