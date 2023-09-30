using System;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Money,
    Happiness,
    Cybersec
}

public class StatesController : MonoBehaviour
{
    public Action<States> OnGameEnded;
    public Action<States, float> OnValueChanged;

    private bool _isGameEnded = false;


    [SerializeField] private float _dayDuration;
    [SerializeField] private float _decreaseDuration;
    [SerializeField] private float _decreaseMoneyCount;
    [SerializeField] private List<State> _states;
    [SerializeField] private List<Sanction> _moneySanctions; 
    private float _dayTimer = 0;
    private float _moneyTimer = 0;

    private void CheckFinishGame()
    {
        if (_isGameEnded) 
            return;

        foreach (var st in _states)
        {
            if(st.currentValue < st.minValue)
            {
                OnGameEnded?.Invoke(st.type);
                break;
            }
        }
    }


    private float GetSanction()
    {
        float sybersecVal = _states.Find(x => x.type == States.Cybersec).currentValue;
        foreach (var s in _moneySanctions)
        {
            if(s.IsThisSanction(sybersecVal, out float sanctionVal))
            {
                return sanctionVal;   
            }
        }
        return 0;
    }


    private void Update()
    {
        if (_isGameEnded)
            return;

        _dayTimer += Time.deltaTime;
        _moneyTimer += Time.deltaTime;
        if (_dayTimer >= _dayDuration)
        {
            EndDay();
            _dayTimer = 0;
        }
        if(_moneyTimer >= _decreaseDuration)
        {
            DecreaseValue(States.Money, _decreaseMoneyCount);
            _moneyTimer = 0;
        }
    }


    public void DecreaseValue(States state, float value)
    {
        State s = _states.Find(x => x.type == state);
        if (!s.TryDecreaseValue(value))
        {
            OnGameEnded?.Invoke(state);
            return;
        }
        OnValueChanged?.Invoke(state, s.currentValue);
    }

    public void IncreaseValue(States state, float value)
    {
        State s = _states.Find(x => x.type == state);
        s.EncreaseValue(value);
        OnValueChanged?.Invoke(state, s.currentValue);
    }

    private void EndDay()
    {
        if (_isGameEnded)
            return;

        print("day");
        foreach (var st in _states)
        {
            if (!st.TryEndDay())
            {
                OnGameEnded?.Invoke(st.type);
                break;
            }
            OnValueChanged?.Invoke(st.type, st.currentValue);
        }
        _states.Find(x => x.type == States.Money).TryDecreaseValue(GetSanction());
        CheckFinishGame();
    }

    private void FinishGame(States _) => _isGameEnded = true;

    private void Awake()
    {
        OnGameEnded += FinishGame;

        foreach (var st in _states)
        {
            st.currentValue = st.defaultValue;
            OnValueChanged?.Invoke(st.type, st.currentValue);
        }
    }
}

[Serializable]
public class State
{
    public States type;
    public float maxValue;
    public float minValue;
    public float currentValue;
    public float defaultValue;


    private float _changeAmountPerDay;

    public bool TryEndDay()
    {
        currentValue = Mathf.Clamp(currentValue + _changeAmountPerDay, minValue, maxValue);
        return currentValue > minValue;
    }

    public bool TryDecreaseValue(float val)
    {
        currentValue -= val;

        return currentValue > minValue;
    }

    public void EncreaseValue(float val)
    {
        currentValue = Mathf.Clamp(currentValue + val, minValue, maxValue); 
    }
}

[Serializable] public class Sanction
{
    public float minValue;
    public float maxValue;
    public float sanctionValue;

    public bool IsThisSanction(float val, out float sanctionVal)
    {
        sanctionVal = 0;
        if(minValue <= val && val <= maxValue)
        {
            sanctionVal = sanctionValue;
            return true;
        }
        return false;
    }
}
