using System;
using Data;

namespace UseCases
{
    public class CalculateDesignersAnnualIncrease : CalculateAnnualIncrease
    {
        private const int SrBaseSalary = 2_000;
        private const int JrBaseSalary = 800;
        
        private const double SrAnnualIncrease = 0.07;
        private const double JrAnnualIncrease = 0.04;

        private readonly ISalaryRepository _salarySalaryRepository;

        public CalculateDesignersAnnualIncrease(ISalaryRepository salaryRepository)
        {
            _salarySalaryRepository = salaryRepository;
        }
        
        public Tuple<double, double> Calculate(Worker worker)
        {
            var currentSalary = _salarySalaryRepository.GetSalaryRecord(worker)?.Salary ?? ObtainBaseSalary(designer: worker);
            var increaseValue = currentSalary * ObtainIncrementalPercentage(designer: worker);
            var newSalary = currentSalary + increaseValue;
            
            return new Tuple<double, double>(Math.Round(newSalary, 2), Math.Round(increaseValue, 2));
        }

        private static double ObtainBaseSalary(Worker designer)
        {
            return designer.Seniority switch
            {
                Seniority.Junior => JrBaseSalary,
                Seniority.Senior => SrBaseSalary,
                _ => 0
            };
        }
        
        private static double ObtainIncrementalPercentage(Worker designer)
        {
            return designer.Seniority switch
            {
                Seniority.Junior => JrAnnualIncrease,
                Seniority.Senior => SrAnnualIncrease,
                _ => 0
            };
        }
    }
}