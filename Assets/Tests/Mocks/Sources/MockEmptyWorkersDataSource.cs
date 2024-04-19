using System.Collections.Generic;
using Data;
using Data.Sources;

namespace Tests.Mocks.Sources
{
    public class MockEmptyWorkersDataSource : IWorkerDataSource
    {
        public bool Fetched;

        public IEnumerable<Worker> FetchWorkers()
        {
            Fetched = true;
            return new List<Worker>();
        }
    }
}