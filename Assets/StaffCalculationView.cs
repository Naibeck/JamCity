using System.Collections;
using System.Collections.Generic;
using Presenters;
using SeviceLocator;
using UnityEngine;
using UnityEngine.UI;

public class StaffCalculationView : MonoBehaviour
{
    public Text CalculatedText;
    public Button CalculateButton;
    
    private ICalculatePresenter _presenter;

    
    // Start is called before the first frame update
    void Start()
    {
        _presenter = ServiceLocator.For(this).Get<ICalculatePresenter>();
        CalculatedText.text = "Tap Calculate to update calculation values for company staff";
        CalculateButton.onClick.AddListener(StartSalaryCalculation);
        
    }

    private void StartSalaryCalculation()
    {
        CalculatedText.text = _presenter.OnCalculateSalary();
    }
}
