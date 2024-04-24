using System.Collections;
using System.Collections.Generic;
using Presenters;
using UnityEngine;

public class CalculatePresenterImpl : ICalculatePresenter
{
    public string OnCalculateSalary() => "Salary was calculated from presenter";
}
