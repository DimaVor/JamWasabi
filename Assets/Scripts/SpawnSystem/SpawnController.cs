using MainView;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SpawnController : MonoBehaviour
{
    private PhoneGenerator _phoneGenerator;
    private FlashGenerator _flashGenerator;

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

    [SerializeField]
    private List<string> _manSurnames = new(){
    "Иванов", "Петров", "Смирнов", "Козлов", "Морозов",
    "Лебедев", "Соколов", "Новиков", "Кузнецов", "Васильев",
    "Горбунов", "Зайцев", "Титов", "Федоров", "Ширяев", "Злочевский",
    "Антонов", "Григорьев", "Семенов", "Карпов", "Павлов",
    "Макаров", "Беляков", "Фомин", "Дорофеев", "Гончаров",
    "Ершов", "Киселев", "Тарасов", "Борисов", "Лазарев",
    "Кудрявцев", "Филиппов", "Мартынов", "Александров", "Колядов",
    "Сорокин", "Герасимов", "Ефимов", "Зимин", "Мещеряков",
    "Гослинг", "Маск", "Цукерберг", "Стэтхэм", "Фамилия"
};

    [SerializeField]
    private List<string> _womanNames = new(){
    "Анна", "Мария", "Елена", "Ольга", "Ирина",
    "Татьяна", "Екатерина", "Наталья", "Светлана", "Лариса",
    "Валентина", "Алиса", "Вера", "Людмила", "Надежда",
    "Дарья", "Ангелина", "Анжела", "Ева", "Инна",
    "Антонина", "Инесса", "Лилия", "Оксана", "Маргарита",
    "Регина", "Яна", "София", "Кристина", "Юлия",
    "Анфиса", "Есения", "Зоя", "Эльвира", "Милена",
    "Галина", "Элина", "Раиса", "Мила", "Марина",
    "Грета", "Алла", "Мэрилин", "Коко", "Жанна"
};


    [SerializeField]
    private List<string> _womanSurnames = new(){
    "Иванова", "Петрова", "Смирнова", "Козлова", "Морозова",
    "Лебедева", "Соколова", "Новикова", "Кузнецова", "Васильева",
    "Горбунова", "Зайцева", "Титова", "Федорова", "Ширяева",
    "Антонова", "Григорьева", "Семенова", "Карпова", "Павлова",
    "Макарова", "Белякова", "Фомина", "Дорофеева", "Гончарова",
    "Ершова", "Киселева", "Тарасова", "Борисова", "Лазарева",
    "Кудрявцева", "Филиппова", "Мартынова", "Александрова", "Колядова",
    "Сорокина", "Герасимова", "Ефимова", "Зимина", "Мещерякова",
    "Иванова", "Петрова", "Смирнова", "Козлова", "Морозова",
    "Тунберг", "Пугачева", "Монро", "Шанель", "Дарк"
};


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
    [SerializeField]
    private List<string> _legitProfessions = new(){
            "Специалист безопасности",
            "Сетевой инженер",
            "Аналитик безопасности",
            "Эксперт данных",
            "Администратор системы",
            "Менеджер инцидентов",
            "Тестировщик безопасности",
            "Архитектор системы",
            "Специалист угроз",
            "Этичный хакер",
            "Аналитик событий",
            "Специалист мониторинга",
            "Эксперт политики",
            "Аудитор данных",
            "Администратор безопасности",
            "Инженер мобильной",
            "Эксперт рисков",
            "Криптограф",
            "Специалист DDoS",
            "Администратор брандмауэра",
            "Кибер аналитик",
            "Эксперт безопасности",
            "Специалист мониторинга",
            "Инженер IoT",
            "Аналитик форензики",
            "Эксперт авторизации",
            "Инженер приложений",
            "Аналитик уязвимостей",
            "Специалист доступа",
            "Эксперт инженерии",
            "Аналитик сети",
            "Специалист событий",
            "Инженер антивируса",
            "Специалист аутентификации",
            "Эксперт восстановления",
            "Кибер консультант",
            "Специалист периметра",
            "Администратор доступа"
        };

    [SerializeField]
    private List<string> _fakeProfessions = new(){
             "Аналитик чужой еды",
             "Специалист по кайфу",
             "Кайфалом",
             "Аналитик смеха",
             "Инженер по смайликам ",
             "Специалист по джемам",
             "Инженер по разработке котят",
             "Инженер по пицце",
             "Уборщик ненужных мыслей",
             "Тестировщик компьютерных кресел",
             "Специалист по опасности",
             "Охранник Пятерочки",
             "Дрессировщик Питона"
    };

    [SerializeField] private int _fakeProfessionPrecent;


    [Space]
    [SerializeField] private List<int> _LegitId = new();
    [SerializeField] private int _fakeIdPrecent;


    [SerializeField] private int _dbPrecent;
    [SerializeField] private List<TextMeshProUGUI> _dbLines = new();
    [SerializeField] private TextMeshProUGUI _virusText;
    [SerializeField] private Image _virusLoading;


    [Inject]
    private CardModel _card;
    [SerializeField] private DragPhone _phone;
    [SerializeField] private RectTransform _phoneSpawnPosition;



    [SerializeField] private HumanView _enterPerson;
    [SerializeField] private HumanView _exitPerson;
    public HumanView EnterPerson => _enterPerson;
    public HumanView ExitPerson => _exitPerson;

    [SerializeField] private HumanView _personPhoto;
    [SerializeField] private int _fakePhotoPrecent;



    private bool canUseEnterPerson = false;
    private bool canUseExitPerson = false;


    [Inject] PcController _pcController;

    private void OnEnable()
    {
        _enterPerson.OnFinishEnter += ShowCardAndPhone;
    }
    private void OnDisable()
    {
        _enterPerson.OnFinishEnter -= ShowCardAndPhone;
    }


    public void GenerateWhiteAndBlackLists()
    {
        _manBlackList.Clear();
        _womanBlackList.Clear();
        _manWhiteList.Clear();
        _manWhiteList.Clear();

        for (int i = 0; i < _whiteListCount; i++)
        {
            bool isMan = HalfRandom();
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
            bool isMan = HalfRandom();
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

    [Inject]
    private SanctionsController _sanctionsController;

    public void AcceptPerson(bool isLeft)
    {
        if (isLeft)
        {
            if (!canUseEnterPerson)
                return;

            _sanctionsController.AcceptEnterPerson(1, 0);



            _enterPerson.HumanDisappear();
        }
        else
        {
            if (!canUseExitPerson)
                return;
            _sanctionsController.AcceptExitPerson(0);
            _exitPerson.HumanDisappear();
        }
    }

    public void DenyPerson()
    {
        if (!canUseEnterPerson)
            return;
        _enterPerson.HumanLeave();
    }


    private void Awake()
    {
        _phoneGenerator = GetComponent<PhoneGenerator>();
        _flashGenerator = GetComponent<FlashGenerator>();

        SpawnNewPerson(false, DateTime.Now);
    }

    private bool HalfRandom() => UnityEngine.Random.Range(0, 2) < 1;



    private int _threats = 0;

    public void SpawnNewPerson(bool isEnter, DateTime date)
    {
        _threats = 0;

        bool isMan = HalfRandom();



        if (isEnter)
        {
            bool isLigitimName = GenerateName(isMan, out string fullName);

            bool isLigitDate = GenerateLastDate(date.Date, out string lastDate);

            bool isLegitProfession = GenerateProfession(out string profession);

            bool isLegitId = GenerateID(out int id);

            bool isLegitCompany = GenerateComapny(out string company);

            _card.SetCard(company, fullName, profession, id, lastDate);

            GeneratePhone(isMan, fullName);

            _enterPerson.GenerateHumanViewFinal(isMan, isMan ? HalfRandom() : false, false, HalfRandom());

            bool isFakePhoto = GeneratePhoto();

            _enterPerson.HumanAppend();


            if (!isLigitimName)
                _threats++;
            if (!isLigitDate)
                _threats++;
            if (!isLegitProfession)
                _threats++;
            if (!isLegitId)
                _threats++;
            if (!isLegitCompany)
                _threats++;



        }
        else
        {
            _exitPerson.GenerateHumanViewFinal(isMan, isMan ? HalfRandom() : false, false, HalfRandom());

            GenerateFlashes();

            _exitPerson.HumanAppend();
        }
    }


    public void ShowCardAndPhone(bool isShow)
    {
        canUseEnterPerson = isShow;
        canUseExitPerson = isShow;


        _card.ShowCard(isShow);

        if (isShow)
            _phone.GetComponent<RectTransform>().anchoredPosition = _phoneSpawnPosition.anchoredPosition;
        else
        {
            var rect = _phone.GetComponent<RectTransform>();
            if (rect.parent.GetComponent<Slot>() != null)
            {
                _pcController.HidePhone();
                rect.SetParent(rect.parent.parent);
            }
        }
        _phone.gameObject.SetActive(isShow);

    }


    private bool GeneratePhoto()
    {
        bool val = IsNotFake(_fakePhotoPrecent);
        if (val)
        {
            _personPhoto.CopyImage(_enterPerson.GetImages(), _enterPerson.GetColor(), _enterPerson.GetBeardEnabled());
        }
        else
        {
            bool isMan = HalfRandom();
            _personPhoto.GenerateHumanViewFinal(isMan, isMan ? HalfRandom() : false, false, HalfRandom());
        }
        return val;
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
        string fullName;
        if (isMan)
        {
            do
            {
                fullName = _manNames[UnityEngine.Random.Range(0, _manNames.Count)] + " " + _manSurnames[UnityEngine.Random.Range(0, _manSurnames.Count)];
            } while (_manBlackList.Contains(fullName) || _manWhiteList.Contains(fullName));
        }
        else
        {
            do
            {
                fullName = _womanNames[UnityEngine.Random.Range(0, _womanNames.Count)] + " " + _womanSurnames[UnityEngine.Random.Range(0, _womanSurnames.Count)];
            } while (_womanBlackList.Contains(fullName) || _womanWhiteList.Contains(fullName));
        }
        return fullName;
    }

    private bool GenerateLastDate(DateTime nowDate, out string date)
    {
        bool val = IsNotFake(_endedDatePrecent);
        var dateT = nowDate.AddDays(val ? UnityEngine.Random.Range(-73, 0) : UnityEngine.Random.Range(0, 123));
        date = dateT.ToString("yyyy/MM/dd");
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



    public bool GenerateDb(bool isMan, string fullName, out List<string> lines)
    {
        lines = new();
        string name = fullName.Split(" ")[0];
        string surname = fullName.Split(' ')[1];

        for (int i = 0; i < 5; i++)
        {
            string newName;
            do
            {
                newName = isMan ? _manNames[UnityEngine.Random.Range(0, _manNames.Count)] : _womanNames[UnityEngine.Random.Range(0, _womanNames.Count)];
            } while (newName == name);
            lines.Add(newName + " " + surname);
        }

        bool inDb = false;
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand < _dbPrecent)
        {
            inDb = true;
            lines[UnityEngine.Random.Range(0, lines.Count)] = fullName;
        }

        return inDb;
    }


    private int GeneratePhone(bool isMan, string fullName)
    {
        bool isBadImage = _phoneGenerator.GenerateImages();
        bool isVirus = _phoneGenerator.GenerateVirus(out string virus);
        bool isDb = GenerateDb(isMan, fullName, out List<string> lines);
        _virusText.gameObject.SetActive(false);
        _virusText.text = virus;
        for (int i = 0; i < lines.Count; i++)
        {
            _dbLines[i].text = lines[i];
        }

        int threads = 0;
        if (!isBadImage)
            threads++;
        if (!isVirus)
            threads++;

       return threads;

    }

    public void AntiVirus()
    {
        StartCoroutine(VirusCoroutine());
    }

    private IEnumerator VirusCoroutine()
    {
        _virusLoading.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        _virusText.gameObject.SetActive(true);
        _virusLoading.gameObject.SetActive(false);
        _virusLoading.gameObject.SetActive(false);
    }

    private void GenerateFlashes()
    {
        List<Flash> flahes = new();
        for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
        {
            flahes.Add(_flashGenerator.GenerateFlash());
        }

        _flashGenerator.SpawnFlashes(flahes);
    }
}
