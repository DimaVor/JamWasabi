using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private List<string> _manNames = new(){
    "Александр", "Михаил", "Иван", "Дмитрий", "Сергей",
    "Андрей", "Павел", "Николай", "Владимир", "Артем",
    "Алексей", "Егор", "Максим", "Денис", "Григорий",
    "Игорь", "Юрий", "Олег", "Роман", "Кирилл",
    "Антон", "Тимофей", "Федор", "Виктор", "Петр",
    "Василий", "Вячеслав", "Станислав", "Анатолий", "Илья",
    "Семен", "Валентин", "Даниил", "Ярослав", "Георгий",
    "Виталий", "Леонид", "Евгений", "Игнат", "Руслан",
    "Райан", "Илон", "Марк", "Джейсон", "Имя"
    };
    [SerializeField] private List<string> _manSurnames = new(){
    "Иванов", "Петров", "Смирнов", "Козлов", "Морозов",
    "Лебедев", "Соколов", "Новиков", "Кузнецов", "Васильев",
    "Горбунов", "Зайцев", "Титов", "Федоров", "Ширяев",
    "Антонов", "Григорьев", "Семенов", "Карпов", "Павлов",
    "Макаров", "Беляков", "Фомин", "Дорофеев", "Гончаров",
    "Ершов", "Киселев", "Тарасов", "Борисов", "Лазарев",
    "Кудрявцев", "Филиппов", "Мартынов", "Александров", "Колядов",
    "Сорокин", "Герасимов", "Ефимов", "Зимин", "Мещеряков",
    "Гослинг", "Маск", "Цукерберг", "Стэтхэм", "Фамилия"
    }; 

    [SerializeField] private List<string> _womanNames = new();
    [SerializeField] private List<string> _womanSurnames = new();


    [Space]
    [SerializeField] private int _inWhiteListPrecent;
    [SerializeField] private int _inBlackListPrecent;

    private List<string> _manBlackList = new();
    private List<string> _womanBlackList = new();
    [SerializeField] private int _blackListCount;

    private List<string> _manWhiteList = new();
    private List<string> _womanWhiteList = new();
    [SerializeField] private int _whiteListCount;


    [Space]
    [SerializeField] private List<string> _ourCompaniesNames = new();
    [SerializeField] private List<string> _otherCompaniesNames = new();
    [SerializeField] private int _otherCompanyPrecent;


    [Space]
    [SerializeField] private int _endedDatePrecent;


    [Space]
    [SerializeField] private List<string> _legitProfessions = new();
    [SerializeField] private List<string> _fakeProfessions = new();
    [SerializeField] private int _fakeProfessionPrecent;


    [Space]
    [SerializeField] private List<int> _LegitId = new();
    [SerializeField] private int _fakeIdPrecent;


    public void GenerateWhiteAndBlackLists()
    {
        _manBlackList.Clear();
        _womanBlackList.Clear();
        _manWhiteList.Clear();
        _manWhiteList.Clear();

        for (int i = 0; i < _whiteListCount; i++)
        {
            bool isMan = GenerateGender();
            name = GenerateRandomName(isMan);
            if (isMan)
            {
                _manWhiteList.Add(name);
            }
            else
            {
                _womanWhiteList.Add(name);
            }
        }

        for (int i = 0; i < _blackListCount; i++)
        {
            bool isMan = GenerateGender();
            name = GenerateRandomName(isMan);
            if (isMan)
            {
                _manBlackList.Add(name);
            }
            else
            {
                _womanBlackList.Add(name);
            }
        }
    }



    private void Awake()
    {
        //for(int i =0; i< 15; i++)
        //{
        //    print(GenerateID(out int id));
        //    print(id);
        //    print("----------------");
        //}
        GenerateWhiteAndBlackLists();
        _manBlackList.ForEach(print);
        _womanBlackList.ForEach(print);
        print("-------------");
        _manWhiteList.ForEach(print);
        _womanWhiteList.ForEach(print);

    }



    public void SpawnNewPerson(bool isEnter, DateTime date)
    {
        bool isMan = GenerateGender();

        bool isLigitimName = GenerateName(isMan, out string name);

        bool isLigitDate = GenerateLastDate(date.Date, out string lastDate);

        bool isFakeProfession = GenerateProfession(out string profession);

        bool isFakeId = GenerateID(out int id);

        bool isFakeCompany = GenerateComapny(out string company);



    }

    public bool GenerateGender()
    {
        bool isMan = true;
        int gender = UnityEngine.Random.Range(0, 2);
        if (gender < 1)
        {
            isMan = false;
        }
        return isMan;
    }
    private bool GenerateName(bool isMan, out string name)
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand < _inWhiteListPrecent)
        {
            if (isMan && _manWhiteList.Count != 0 || !isMan && _womanWhiteList.Count != 0)
            {
                name = isMan ? _manWhiteList[UnityEngine.Random.Range(0, _manWhiteList.Count)] : _womanWhiteList[UnityEngine.Random.Range(0, _womanWhiteList.Count)];
                _manWhiteList.Remove(name);
                _womanWhiteList.Remove(name);
                return true;
            }
        }
        rand = UnityEngine.Random.Range(0, 100);
        if (rand < _inBlackListPrecent)
        {
            if (isMan && _manBlackList.Count != 0 || !isMan && _womanBlackList.Count != 0)
            {
                name = isMan ? _manBlackList[UnityEngine.Random.Range(0, _manBlackList.Count)] : _womanBlackList[UnityEngine.Random.Range(0, _womanBlackList.Count)];
                _manBlackList.Remove(name);
                _womanBlackList.Remove(name);
                return false;
            }
        }
        name = GenerateRandomName(isMan);
        return true;
    }

    private string GenerateRandomName(bool isMan) 
    {
        if (isMan)
        {
            do
            {
                 name = _manNames[UnityEngine.Random.Range(0, _manNames.Count)] + " " + _manSurnames[UnityEngine.Random.Range(0, _manSurnames.Count)];
            } while (_manBlackList.Contains(name) || _manWhiteList.Contains(name));
        }
        else
        {
            do
            {
                name = _womanNames[UnityEngine.Random.Range(0, _womanNames.Count)] + " " + _womanSurnames[UnityEngine.Random.Range(0, _womanSurnames.Count)];
            } while (_womanBlackList.Contains(name) || _womanWhiteList.Contains(name));
        }
        return name;
    }

    private bool GenerateLastDate(DateTime nowDate, out string date)
    {
        bool val = IsNotFake(_endedDatePrecent);
        var dateT = nowDate.AddDays(val ? UnityEngine.Random.Range(-73, 0) : UnityEngine.Random.Range(0, 123));
        date = dateT.ToString("yyyy:MM:dd");
        return val;
    }

    private bool GenerateProfession(out string profession)
    {
        bool val = IsNotFake(_fakeProfessionPrecent);
        profession = val ? _legitProfessions[UnityEngine.Random.Range(0, _legitProfessions.Count)] : _fakeProfessions[UnityEngine.Random.Range(0, _fakeProfessions.Count)];
        return val;
    }

    public bool GenerateID(out int id)
    {
        bool val = IsNotFake(_fakeIdPrecent);
        id = val ? _LegitId[UnityEngine.Random.Range(0, _LegitId.Count)] * 1000 + RandomNumber(3) : RandomNumber(5);
        return val;
    }

    private bool GenerateComapny(out string company)
    {
        bool val = IsNotFake(_otherCompanyPrecent);
        company = val ? _ourCompaniesNames[UnityEngine.Random.Range(0, _ourCompaniesNames.Count)] : _otherCompaniesNames[UnityEngine.Random.Range(0, _otherCompaniesNames.Count)];
        return val;
    }


    private bool IsNotFake(int fakePrecent)
    {
        int rand = UnityEngine.Random.Range(0, 100);
        return !(rand < fakePrecent);
    }


    public int RandomNumber(int digtNumber) => UnityEngine.Random.Range(0, (int)Mathf.Pow(10, digtNumber));
}
