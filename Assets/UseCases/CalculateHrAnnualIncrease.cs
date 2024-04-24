using System;
using Data;

namespace UseCases
{
    public class CalculateHrAnnualIncrease : ICalculateAnnualIncrease
    {
        private const int SrBaseSalary = 1_500;
        private const int SsrBaseSalary = 1_000;
        private const int JrBaseSalary = 500;
        
        private const double SrAnnualIncrease = 0.05;
        private const double SsrAnnualIncrease = 0.02;
        private const double JrAnnualIncrease = 0.005;

        private readonly ISalaryRepository _salarySalaryRepository;

        public CalculateHrAnnualIncrease(ISalaryRepository salaryRepository)
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
                Seniority.Junior => JrBaseSalary,
                _ => 0
            };
        }
        
        private static double ObtainIncrementalPercentage(Worker pm)
        {
            return pm.Seniority switch
            {
                Seniority.SemiSenior => SsrAnnualIncrease,
                Seniority.Senior => SrAnnualIncrease,
                Seniority.Junior => JrAnnualIncrease,
                _ => 0
            };
        }
    }
}