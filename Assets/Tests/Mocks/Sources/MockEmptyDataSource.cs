using System;
using System.Collections.Generic;
using Data;
using Data.Sources;

namespace Tests.Mocks.Sources
{
    public class MockEmptyDataSource : WorkerDataSource
    {
        public Boolean Fetched;

        public IEnumerable<Workers> FetchWorkers()
        {
            Fetched = true;
            return new List<Workers>();
        }
    }
}