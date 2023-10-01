using UnityEngine;

public class SanctionsController : MonoBehaviour
{
    private StatesController _statesController;

    [SerializeField] private float _cardSanctionAmount;
    [SerializeField] private float _cardBonusAmount;
    

    [Space]
    [SerializeField] private float _employeeBonus;


    [Space]
    [SerializeField] private float _normalWaitingTime;
    [SerializeField] private float _tooLongWaitingTime;
    [SerializeField] private float _waitingBonus;
    [SerializeField] private float _waitingSanction;


    public void AcceptEnterPerson(int wrongFieldsCount, float WaitingTime)
    {
        _statesController.IncreaseValue(States.Money, _employeeBonus);

        if (wrongFieldsCount == 0)
        {
            _statesController.IncreaseValue(States.Cybersec, _cardBonusAmount);
        }
        else
        {
            _statesController.DecreaseValue(States.Cybersec, wrongFieldsCount * _cardSanctionAmount);
        }


    }

    public void CheckWaitTime()
    {

    }
}
