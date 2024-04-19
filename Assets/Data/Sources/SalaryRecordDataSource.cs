using System.Collections.Generic;

namespace Data.Sources
{
    /**
     * Use this interface to represent all potential data sources where data can be avaialble (network, mock, database, cache)
     */
    public interface ISalaryRecordDataSource
    {
        IEnumerable<SalaryRecord> FetchSalaries();
    }
}