using System;
using System.Collections.Generic;
using Data;
using Data.Sources;

namespace Tests.Mocks.Sources
{
    public class MockCrashWorkersDataSource : IWorkerDataSource
    {
        private IEnumerable<Worker> _workers;
        
        public bool Fetched;
        
        public IEnumerable<Worker> FetchWorkers()
        {
            Fetched = true;
            throw new Exception("An error ocurred");
        }
    }
}