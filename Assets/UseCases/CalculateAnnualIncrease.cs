using System;
using Data;

namespace UseCases
{
    public interface CalculateAnnualIncrease
    {
        Tuple<double, double> Calculate(Worker worker);
    }
}