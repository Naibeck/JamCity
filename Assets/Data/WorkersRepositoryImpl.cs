using System;
using System.Collections.Generic;
using Data.Sources;

namespace Data
{
    public class WorkersRepositoryImpl : IWorkersRepository
    {

        private readonly IWorkerDataSource _workerDataSource;
        
        public WorkersRepositoryImpl(IWorkerDataSource dataSource)
        {
            _workerDataSource = dataSource;
        }
        
        public IEnumerable<Worker> LoadWorkers()
        {
            try
            {
                return _workerDataSource.FetchWorkers();
            }
            catch (Exception)
            { 
                return new Worker[]{};
            }
        }
    }
}