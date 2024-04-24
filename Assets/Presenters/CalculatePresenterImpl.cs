using UnityEngine;
using UseCases;

namespace Presenters
{
    public class CalculatePresenterImpl : MonoBehaviour, ICalculatePresenter
    {
        private ICalculateAnnualIncrease _hrIncrease;
        private ICalculateAnnualIncrease _engineersIncrease;
        private ICalculateAnnualIncrease _artistIncrease;
        private ICalculateAnnualIncrease _designIncrease;
        private ICalculateAnnualIncrease _pmsIncrease;
        private ICalculateAnnualIncrease _ceoIncrease;
        
        public CalculatePresenterImpl()
        {
            
        }

        public string OnCalculateSalary() => "Salary was calculated from presenter";
    }
}
