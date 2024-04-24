using System;
using Data;

namespace UseCases
{
    public class CalculateCeoAnnualIncrease : ICalculateAnnualIncrease
    {
        private const int BaseSalary = 20_000;
        private const double AnnualIncrease = 1.0;

        private readonly ISalaryRepository _salarySalaryRepository;

        public CalculateCeoAnnualIncrease(ISalaryRepository salaryRepository)
        {
            _salarySalaryRepository = salaryRepository;
        }
        
        public Tuple<double, double> Calculate(Worker worker)
        {
            var currentSalary = _salarySalaryRepository.GetSalaryRecord(worker)?.Salary ?? BaseSalary;
            var increaseValue = currentSalary * AnnualIncrease;
            var newSalary = currentSalary + increaseValue;
            
            return new Tuple<double, double>(Math.Round(newSalary, 2), Math.Round(increaseValue, 2));
        }
    }
}