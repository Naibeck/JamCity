using System.Collections;
using System.Collections.Generic;
using Data;
using Data.Sources;
using UnityEngine;

public class SalaryDataSource : MonoBehaviour, ISalaryRecordDataSource
{
    private IEnumerable<SalaryRecord> _salaryRecords = new SalaryRecord[] { };

    public IEnumerable<SalaryRecord> FetchSalaries() => _salaryRecords;
}
