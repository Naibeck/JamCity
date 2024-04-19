using System;
using Data;

namespace UseCases
{
    public class CalculatePmsAnnualIncrease : CalculateAnnualIncrease
    {
        private const int SrBaseSalary = 4_000;
        private const int SsrBaseSalary = 2_400;
        
        private const double SrAnnualIncrease = 0.1;
        private const double SsrAnnualIncrease = 0.05;

        private readonly ISalaryRepository _salarySalaryRepository;

        public CalculatePmsAnnualIncrease(ISalaryRepository salaryRepository)
        {
            _salarySalaryRepository = salaryRepository;
        }
        
        public Tuple<double, double> Calculate(Worker worker)
        {
            var currentSalary = _salarySalaryRepository.GetSalaryRecord(worker)?.Salary ?? ObtainBaseSalary(pm: worker);
            var increaseValue = currentSalary * ObtainIncrementalPercentage(pm: worker);
            var newSalary = currentSalary + increaseValue;
            
            return new Tuple<double, double>(Math.Round(newSalary, 2), Math.Round(increaseValue, 2));
        }

        private static double ObtainBaseSalary(Worker pm)
        {
            return pm.Seniority switch
            {
                Seniority.SemiSenior => SsrBaseSalary,
                Seniority.Senior => SrBaseSalary,
                _ => 0
            };
        }
        
        private static double ObtainIncrementalPercentage(Worker pm)
        {
            return pm.Seniority switch
            {
                Seniority.SemiSenior => SsrAnnualIncrease,
                Seniority.Senior => SrAnnualIncrease,
                _ => 0
            };
        }
    }
}