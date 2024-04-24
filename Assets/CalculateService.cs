using Presenters;
using UnityEngine;
using UnityEngine.UI;

public class CalculateService : MonoBehaviour
{
    public Text CalculatedText;
    public Button CalculateButton;
    public GameObject Presenter;
    
    private ICalculatePresenter _presenter;
    
    // Start is called before the first frame update
    void Start()
    {
        _presenter = Presenter.GetComponent<ICalculatePresenter>();
        CalculatedText.text = "New value coming from BL";
        CalculateButton.onClick.AddListener(StartSalaryCalculation);
    }

    private void StartSalaryCalculation()
    {
        CalculatedText.text = _presenter.OnCalculateSalary();
    }
}
