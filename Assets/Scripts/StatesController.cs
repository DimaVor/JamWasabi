using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private float _decreaseDuration;
    [SerializeField] private float _decreaseMoneyCount;
    [SerializeField] private List<State> _states;
    [SerializeField] private List<Sanction> _moneySanctions;

    [SerializeField] private float _fillSpeed;



    [SerializeField] private List<Slider> _sliders = new();
    private List<Image> _sliderImages = new();
    [SerializeField] private Color _badColor;
    [SerializeField] private Color _normColor;
    [SerializeField] private Color _goodColor;


    private float _moneyTimer = 0;

    private void CheckFinishGame()
    {
        if (_isGameEnded)
            return;

        foreach (var st in _states)
        {
            if (st.currentValue < st.minValue)
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
            if (s.IsThisSanction(sybersecVal, out float sanctionVal))
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

        _moneyTimer += Time.deltaTime;

        if (_moneyTimer >= _decreaseDuration)
        {
            DecreaseValue(States.Money, _decreaseMoneyCount);
            _moneyTimer = 0;
        }


        for (int i = 0; i < _sliders.Count; i++)
        {
            var currentState = _states.Find(x => x.type == (States)i);

            if (_sliders[i].value <= .3)
            {
                _sliderImages[i].color = _badColor;
            }
            else if (_sliders[i].value <= .6)
            {
                _sliderImages[i].color = _normColor;
            }
            else _sliderImages[i].color = _goodColor;


            if (_sliders[i].value < currentState.currentValue / (currentState.maxValue - currentState.minValue))
            {
                _sliders[i].value += _fillSpeed * Time.deltaTime;
            }
            if (_sliders[i].value > currentState.currentValue / (currentState.maxValue - currentState.minValue))
            {
                _sliders[i].value -= _fillSpeed * Time.deltaTime;
            }
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

    public void EndDay()
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

        for (int i = 0; i < _sliders.Count; i++)
        {
            var currentState = _states.Find(x => x.type == (States)i);
            _sliders[i].value = currentState.currentValue / (currentState.maxValue - currentState.minValue);
            _sliderImages.Add(_sliders[i].fillRect.GetComponent<Image>());

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

[Serializable]
public class Sanction
{
    public float minValue;
    public float maxValue;
    public float sanctionValue;

    public bool IsThisSanction(float val, out float sanctionVal)
    {
        sanctionVal = 0;
        if (minValue <= val && val <= maxValue)
        {
            sanctionVal = sanctionValue;
            return true;
        }
        return false;
    }
}
