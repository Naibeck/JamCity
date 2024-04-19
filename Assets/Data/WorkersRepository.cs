using System.Collections.Generic;

namespace Data
{
    public interface IWorkersRepository
    {
        IEnumerable<Worker> LoadWorkers();
    }
}