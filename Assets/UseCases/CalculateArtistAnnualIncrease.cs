using System;
using Data;

namespace UseCases
{
    public class CalculateArtistAnnualIncrease : CalculateAnnualIncrease
    {
        private const int SrBaseSalary = 2_000;
        private const int SsrBaseSalary = 1_200;
        
        private const double SrAnnualIncrease = 0.05;
        private const double SsrAnnualIncrease = 0.025;

        private readonly ISalaryRepository _salarySalaryRepository;

        public CalculateArtistAnnualIncrease(ISalaryRepository salaryRepository)
        {
            _salarySalaryRepository = salaryRepository;
        }
        
        public Tuple<double, double> Calculate(Worker worker)
        {
            var currentSalary = _salarySalaryRepository.GetSalaryRecord(worker)?.Salary ?? ObtainBaseSalary(artist: worker);
            var increaseValue = currentSalary * ObtainIncrementalPercentage(artist: worker);
            var newSalary = currentSalary + increaseValue;
            
            return new Tuple<double, double>(Math.Round(newSalary, 2), Math.Round(increaseValue, 2));
        }

        private static double ObtainBaseSalary(Worker artist)
        {
            return artist.Seniority switch
            {
                Seniority.SemiSenior => SsrBaseSalary,
                Seniority.Senior => SrBaseSalary,
                _ => 0
            };
        }
        
        private static double ObtainIncrementalPercentage(Worker artist)
        {
            return artist.Seniority switch
            {
                Seniority.SemiSenior => SsrAnnualIncrease,
                Seniority.Senior => SrAnnualIncrease,
                _ => 0
            };
        }
    }
}