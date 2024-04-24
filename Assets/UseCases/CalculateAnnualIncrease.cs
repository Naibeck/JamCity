using System;
using Data;

namespace UseCases
{
    public interface ICalculateAnnualIncrease
    {
        Tuple<double, double> Calculate(Worker worker);
    }
}