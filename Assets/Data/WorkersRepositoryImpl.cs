using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public IEnumerable<Worker> LoadWorkers(bool sort = false)
        {
            try
            {
                return sort ? 
                    _workerDataSource.FetchWorkers().OrderByDescending(worker => worker.Seniority) :
                    _workerDataSource.FetchWorkers();
            }
            catch (Exception)
            { 
                return new Worker[]{};
            }
        }
    }
}