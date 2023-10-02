using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QueueController : MonoBehaviour
{
    [Inject]
    private StatesController _statesController;

    [SerializeField] private TextMeshProUGUI _date;
    [SerializeField] private List<TextMeshProUGUI> _hours;

    [SerializeField] private Image _manPrefab;
    [SerializeField] private Vector2 _offset;



    [Inject]
    private SpawnController _spawnController;

    [SerializeField] private int _enterPersonsCounter = 0;
    [SerializeField] private bool _canSpawnEnterPerson = true;
    [SerializeField] private RectTransform _enterRoot;
    [SerializeField] private RectTransform _exitRoot;


    [SerializeField] private int _exitPersonsCounter = 0;
    [SerializeField] private bool _canSpawnExitPerson = true;

    [SerializeField] private int _enterMinTime;
    [SerializeField] private int _enterMaxTime;

    [SerializeField] private int _exitMinTime;
    [SerializeField] private int _exitMaxTime;

    [SerializeField] private float _dayTimeInSeconds;

    private DateTime _startDate = new(2023, 10, 01, 9, 0, 0);

    private float realTime = 0;

    private bool isDayEnded = true;


    private void OnEnable()
    {
        _spawnController.EnterPerson.OnCanSpawnNew += ProcessEnterHumanEvent;
        _spawnController.ExitPerson.OnCanSpawnNew += ProcessExitHumanEvent;
    }

    private void OnDisable()
    {
        _spawnController.EnterPerson.OnCanSpawnNew -= ProcessEnterHumanEvent;
        _spawnController.ExitPerson.OnCanSpawnNew -= ProcessExitHumanEvent;
    }

    private void ProcessEnterHumanEvent(bool val)
    {
        _canSpawnEnterPerson = val;
    }

    private void ProcessExitHumanEvent(bool val)
    {
        _canSpawnExitPerson = val;
    }

    private void Awake()
    {
        isDayEnded = false;
        realTime = 0;
        var date = ModificateTime(realTime);
        _date.text = date.ToString("dd/MM/yyyy");
        _spawnController.EnterPerson.GoSpawn();
        _spawnController.ExitPerson.GoSpawn();
        StartCoroutine(RespawnCoroutine(true));
        StartCoroutine(RespawnCoroutine(false));
    }


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

        if (_enterPersonsCounter > 0 && _canSpawnEnterPerson)
        {
            SpawnNewPerson(true);
        }
        if (_exitPersonsCounter > 0 && _canSpawnExitPerson)
        {
            SpawnNewPerson(false);
        }


        realTime += Time.deltaTime;
        var date = ModificateTime(realTime);

        _hours[0].text = date.ToString("HH")[0].ToString();
        _hours[1].text = date.ToString("HH")[1].ToString();
        _hours[2].text = date.ToString("mm")[0].ToString();
        _hours[3].text = date.ToString("mm")[1].ToString();
    }

    private void SpawnPerson(bool isLeft, bool isSpawn)
    {
        if (isLeft)
        {
            if (isSpawn)
            {
                var pr = Instantiate(_manPrefab, _enterRoot);
                pr.GetComponent<RectTransform>().anchoredPosition = new Vector2(-_offset.x * _enterPersonsCounter, 0);
                
            }
            else
            {
                if(_enterRoot.childCount != 0 )
                    Destroy(_enterRoot.GetChild(_enterRoot.childCount-1).gameObject);
            }
        }
        else
        {
            if (isSpawn)
            {
                var pr = Instantiate(_manPrefab, _exitRoot);
                pr.GetComponent<RectTransform>().anchoredPosition = new Vector2(_offset.x * _exitPersonsCounter, 0);

            }
            else
            {
                if (_exitRoot.childCount != 0)
                    Destroy(_exitRoot.GetChild(_exitRoot.childCount-1).gameObject);
            }
        }
    }

    public void EndDay()
    {
        isDayEnded = true;
        StopAllCoroutines();



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
        _date.text = date.ToString("dd/MM/yyyy");
        _isQueueActive = true;
        _spawnController.SpawnNewPerson(isEnter, date);
    }


    private IEnumerator RespawnCoroutine(bool isEnter)
    {
        int time = isEnter ? UnityEngine.Random.Range(_enterMinTime, _enterMaxTime + 1) : UnityEngine.Random.Range(_exitMinTime, _exitMaxTime + 1);
        yield return new WaitForSeconds(time);
        if (isEnter)
        {
            _enterPersonsCounter++;
        }
        else
        {
            _exitPersonsCounter++;
        }

        SpawnPerson(isEnter, true);

        RestartCor(isEnter);
    }

    private void RestartCor(bool isEnter) => StartCoroutine(RespawnCoroutine(isEnter));

    private void SpawnNewPerson(bool isEnter)
    {
        if (isEnter)
            _enterPersonsCounter--;
        else
            _exitPersonsCounter--;

        SpawnPerson(isEnter, false);

        _spawnController.SpawnNewPerson(isEnter, ModificateTime(realTime));
    }


    public void StopQueue(bool isEnter)
    {
        _isQueueActive = false;
    }
}
