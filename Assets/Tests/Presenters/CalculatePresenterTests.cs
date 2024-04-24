using NUnit.Framework;
using Presenters;

namespace Tests.Presenters
{
    public class CalculatePresenterTests
    {
        [Test]
        public void CalculateResultsShouldReturnANonEmptyString()
        {
            const string expected = "Salary was calculated from presenter";
            var presenter = new CalculatePresenterImpl();
            var result = presenter.OnCalculateSalary();
            
            Assert.AreEqual(expected, result);
        }
    }
}