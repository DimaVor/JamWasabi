using TMPro;
using UnityEngine;

public class BarCheck : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI cybersec;
    [SerializeField] private TextMeshProUGUI happinnes;
    [SerializeField] private StatesController _statesController;


    private void Start()
    {
        _statesController.OnValueChanged += ChangeUi;
        _statesController.OnGameEnded += End;
    }

    private void End(States s) => print("end");

    private void ChangeUi(States state, float val)
    {
        switch (state)
        {
            case States.Money:
                {
                    money.text = "money " + val.ToString();
                    break;
                }
            case States.Happiness:
                {
                    happinnes.text = "hap " + val.ToString();
                    break;
                }
            case States.Cybersec:
                {
                    cybersec.text = "sybersec "+val.ToString();
                    break;
                }
            default:
                break;
        }

    }


    public void DecreaseSybersec() => _statesController.DecreaseValue(States.Cybersec, 10);
    public void IncreaseSybersec() => _statesController.IncreaseValue(States.Cybersec, 5);
    public void DecreaseHap() => _statesController.DecreaseValue(States.Happiness, 10);
    public void IncreaseHap() => _statesController.IncreaseValue(States.Happiness, 5);
    public void DecreaseMoney() => _statesController.DecreaseValue(States.Money, 10);
    public void IncreaseMoney() => _statesController.IncreaseValue(States.Money, 5);

}
