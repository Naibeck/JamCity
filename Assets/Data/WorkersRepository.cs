using System.Collections.Generic;

namespace Data
{
    public interface WorkersRepository
    {
        IEnumerable<Workers> LoadWorkers();
    }
}