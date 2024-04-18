using System.Collections.Generic;
using Data.Sources;

namespace Data
{
    public class WorkersRepositoryImpl : WorkersRepository
    {

        private WorkerDataSource _workerDataSource;
        
        public WorkersRepositoryImpl(WorkerDataSource dataSource)
        {
            _workerDataSource = dataSource;
        }
        public IEnumerable<Workers> LoadWorkers()
        {
            return _workerDataSource.FetchWorkers();
        }
    }
}