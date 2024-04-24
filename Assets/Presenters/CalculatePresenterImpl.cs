using UseCases;

namespace Presenters
{
    public class CalculatePresenterImpl : ICalculatePresenter
    {
        public string OnCalculateSalary() => "Salary was calculated from presenter";
    }
}
