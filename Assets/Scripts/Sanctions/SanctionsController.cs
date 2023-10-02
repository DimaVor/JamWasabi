using UnityEngine;
using Zenject;

public class SanctionsController : MonoBehaviour
{
    [Inject]
    private StatesController _statesController;

    [SerializeField] private float _cardSanctionAmount;
    [SerializeField] private float _cardBonusAmount;
    [SerializeField] private float _flashSanctionAmount;


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

        CheckWaitTime(WaitingTime);
    }

    public void AcceptExitPerson(float waitingTime)
    {
        var flashes = FindObjectsOfType<DragFlash>();
        int badFilesNum = 0;
        foreach (var flash in flashes)
        {
            badFilesNum += flash.Model.GetNumOfBadFiles();
        }

        _statesController.DecreaseValue(States.Cybersec, badFilesNum * _flashSanctionAmount);

        if (waitingTime > 0)
        {
            CheckWaitTime(waitingTime);
        }
    }




    public void CheckWaitTime(float waitingTime)
    {
        if (waitingTime <= _normalWaitingTime)
        {
            _statesController.IncreaseValue(States.Happiness, _waitingBonus);
            return;
        }
        if (waitingTime > _tooLongWaitingTime)
        {
            _statesController.DecreaseValue(States.Happiness, _waitingSanction);
        }
    }

}
