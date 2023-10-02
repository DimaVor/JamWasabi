using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class QueueController : MonoBehaviour
{
    [Inject]
    private StatesController _statesController;

    [SerializeField] private TextMeshProUGUI _date;
    [SerializeField] private List<TextMeshProUGUI> _hours;



    [Inject] 
    private SpawnController _spawnController;
    private Queue<string> _enterPersons;
    private Queue<string> _exitPersons;

    [SerializeField] private int _enterMinTime;
    [SerializeField] private int _enterMaxTime;

    [SerializeField] private int _exitMinTime;
    [SerializeField] private int _exitMaxTime;

    [SerializeField] private float _dayTimeInSeconds;

    private DateTime _startDate = new(2023, 10, 01, 9, 0, 0);

    private float realTime = 0;

    private bool isDayEnded = false;


    private void Update()
    {
        if (isDayEnded)
        {
            return;
        }

        if (realTime > _dayTimeInSeconds)
        {
            EndDay();
        }

        realTime += Time.deltaTime;
        var date = ModificateTime(realTime);
        _date.text = date.ToString("dd/MM/yyyy");
        _hours[0].text = date.ToString("HH")[0].ToString();
        _hours[1].text = date.ToString("HH")[1].ToString();
        _hours[2].text = date.ToString("mm")[0].ToString();
        _hours[3].text = date.ToString("mm")[1].ToString();



        

    }

    public void EndDay()
    {
        isDayEnded = true;




        _statesController.EndDay();
        
    }

    private DateTime ModificateTime(float realTime)
    {
        int totalIngameMinutes = (18 - 9) * 60;
        float multiplier = totalIngameMinutes / _dayTimeInSeconds;
        float currentIngameMinutes = multiplier * realTime;
        int currentIngameHours = _startDate.Hour + (int)(currentIngameMinutes / 60);
        return new(2023, 10, 01, currentIngameHours, (int)(currentIngameMinutes % 60), 0);
    }



    private bool _isQueueActive;
    public void StartQueue(bool isEnter, DateTime date)
    {
        _isQueueActive = true;
        _spawnController.SpawnNewPerson(isEnter, date);
    }


    private IEnumerator RespawnCoroutine(bool isEnter)
    {
        int time = isEnter ? UnityEngine.Random.Range(_enterMinTime, _enterMaxTime + 1) : UnityEngine.Random.Range(_exitMinTime, _exitMaxTime + 1);
        yield return new WaitForSeconds(time);
        SpawnNewPerson(isEnter);

    }

    private void SpawnNewPerson(bool isEnter)
    {
        _spawnController.SpawnNewPerson(isEnter, ModificateTime(realTime));
        StartCoroutine(RespawnCoroutine(isEnter));
    }


    public void StopQueue(bool isEnter)
    {
        _isQueueActive = false;
    }
}
