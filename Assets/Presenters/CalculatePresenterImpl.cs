using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UseCases;

namespace Presenters
{
    public class CalculatePresenterImpl : ICalculatePresenter
    {
        private readonly IWorkersRepository _repository;
        private readonly ICalculateAnnualIncrease _hrIncrease;
        private readonly ICalculateAnnualIncrease _engineersIncrease;
        private readonly ICalculateAnnualIncrease _artistIncrease;
        private readonly ICalculateAnnualIncrease _designIncrease;
        private readonly ICalculateAnnualIncrease _pmsIncrease;
        private readonly ICalculateAnnualIncrease _ceoIncrease;
        
        public CalculatePresenterImpl(
            IWorkersRepository repository,
            ICalculateAnnualIncrease hrIncrease, 
            ICalculateAnnualIncrease engineersIncrease, 
            ICalculateAnnualIncrease artistIncrease, 
            ICalculateAnnualIncrease designIncrease, 
            ICalculateAnnualIncrease pmsIncrease, 
            ICalculateAnnualIncrease ceoIncrease
        ) {
            _repository = repository;
            _hrIncrease = hrIncrease;
            _engineersIncrease = engineersIncrease;
            _artistIncrease = artistIncrease;
            _designIncrease = designIncrease;
            _pmsIncrease = pmsIncrease;
            _ceoIncrease = ceoIncrease;
        }

        public string OnCalculateSalary() =>
            _repository.LoadWorkers(sort: true)
                .GroupBy(worker => worker.Position)
                .OrderBy(group => group.Key)
                .ToDictionary(group => group.Key, group => group.AsEnumerable())
                .Select(position => FormatWorkerDepartmentIncreaseSalary(workers: position.Value))
                .Aggregate((current, next) => current + "\n" + next);

        private string FormatWorkerDepartmentIncreaseSalary(IEnumerable<Worker> workers)
        {
            var currentWorkers = workers.ToList();
            var totalSalary = currentWorkers.Sum(worker => worker.Position switch
            {
                Position.HR => _hrIncrease.Calculate(worker).Item1,
                Position.Engineering => _engineersIncrease.Calculate(worker).Item1,
                Position.Artist => _artistIncrease.Calculate(worker).Item1,
                Position.Design => _designIncrease.Calculate(worker).Item1,
                Position.PM => _pmsIncrease.Calculate(worker).Item1,
                Position.CEO => _ceoIncrease.Calculate(worker).Item1,
                _ => throw new ArgumentOutOfRangeException()
            });

            return $"{currentWorkers.First().Position} Workers: {currentWorkers.Count} total salary: {totalSalary}";
        }
    }
}
