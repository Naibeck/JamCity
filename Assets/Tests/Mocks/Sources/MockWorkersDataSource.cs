using System.Collections.Generic;
using Data;
using Data.Sources;

namespace Tests.Mocks.Sources
{
    public class MockWorkersDataSource : IWorkerDataSource
    {
        private IEnumerable<Worker> _workers;
        
        public bool Fetched;

        public MockWorkersDataSource(IEnumerable<Worker> workers)
        {
            _workers = workers;
        }
        
        public IEnumerable<Worker> FetchWorkers()
        {
            Fetched = true;
            return _workers;
        }
    }
}