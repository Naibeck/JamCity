using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UseCases;

namespace Presenters
{
    public class CalculatePresenterImpl : ICalculatePresenter
    {
        private IWorkersRepository _repository;
        private ICalculateAnnualIncrease _hrIncrease;
        private ICalculateAnnualIncrease _engineersIncrease;
        private ICalculateAnnualIncrease _artistIncrease;
        private ICalculateAnnualIncrease _designIncrease;
        private ICalculateAnnualIncrease _pmsIncrease;
        private ICalculateAnnualIncrease _ceoIncrease;
        
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

        public string OnCalculateSalary()
        {
            var hrFormatted = FormatWorkerDepartmentIncreaseSalary(workers: HrWorkers());
            var engineersFormatted = FormatWorkerDepartmentIncreaseSalary(workers: EngineersWorkers());
            var artistsFormatted = FormatWorkerDepartmentIncreaseSalary(workers: ArtistsWorkers());
            var designersFormatted = FormatWorkerDepartmentIncreaseSalary(workers: DesignersWorkers());
            var pmsFormatted = FormatWorkerDepartmentIncreaseSalary(workers: PmsWorkers());
            var ceoFormatted = FormatWorkerDepartmentIncreaseSalary(workers: CeoWorkers());
            return hrFormatted + "\n" + engineersFormatted + "\n" + artistsFormatted + "\n" + designersFormatted + "\n" + pmsFormatted + "\n" + ceoFormatted;
        }

        private string FormatWorkerDepartmentIncreaseSalary(IEnumerable<Worker> workers)
        {
            var currentWorkers = workers.ToList();
            double totalSalary = 0.0;
            foreach (var worker in currentWorkers)
            {
                var newSalary = 0.0;
                switch (worker.Position)
                {
                    case Position.HR:
                        newSalary = _hrIncrease.Calculate(worker).Item1;
                        break;
                    case Position.Engineering:
                        newSalary = _engineersIncrease.Calculate(worker).Item1;
                        break;
                    case Position.Artist:
                        newSalary = _artistIncrease.Calculate(worker).Item1;
                        break;
                    case Position.Design:
                        newSalary = _designIncrease.Calculate(worker).Item1;
                        break;
                    case Position.PM:
                        newSalary = _pmsIncrease.Calculate(worker).Item1;
                        break;
                    case Position.CEO:
                        newSalary = _ceoIncrease.Calculate(worker).Item1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                totalSalary += newSalary;
            }
            
            return currentWorkers.First().Position + " Workers: " + currentWorkers.Count() + " total salary: " + totalSalary;
        }

        private IEnumerable<Worker> HrWorkers() => _repository.LoadWorkers().Where(worker => worker.Position.Equals(Position.HR));
        private IEnumerable<Worker> EngineersWorkers() => _repository.LoadWorkers().Where(worker => worker.Position.Equals(Position.Engineering));
        private IEnumerable<Worker> ArtistsWorkers() => _repository.LoadWorkers().Where(worker => worker.Position.Equals(Position.Artist));
        private IEnumerable<Worker> DesignersWorkers() => _repository.LoadWorkers().Where(worker => worker.Position.Equals(Position.Design));
        private IEnumerable<Worker> PmsWorkers() => _repository.LoadWorkers().Where(worker => worker.Position.Equals(Position.PM));
        private IEnumerable<Worker> CeoWorkers() => _repository.LoadWorkers().Where(worker => worker.Position.Equals(Position.CEO));
    }
}
