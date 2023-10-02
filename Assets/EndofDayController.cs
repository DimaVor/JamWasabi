using UnityEngine;

public class EndofDayController : MonoBehaviour
{
    [SerializeField] private RectTransform _win;
    [SerializeField] private RectTransform _lose;

    private bool isLose = false;

    public void ShowWin(bool val)
    {
        if (isLose)
            return;
        _win.gameObject.SetActive(val);
    }
    public void ShowLose(bool val)
    {
        if (val)
            isLose = true;
        _lose.gameObject.SetActive(val);
    }

    private bool isOpen1 = false;
    private int counter1 = 0;

    [SerializeField] private RectTransform _help1;
    [SerializeField] private RectTransform _help2;

    [SerializeField] private RectTransform _help3;
    [SerializeField] private RectTransform _help4;
    [SerializeField] private RectTransform _help5;


    private bool isOpen2 = false;
    private int counter2 = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!isOpen1)
            {
                _help1.gameObject.SetActive(true);
                counter1 = 1;
                isOpen1 = true;
            }
            else if (counter1 == 1)
            {
                _help1.gameObject.SetActive(false);
                _help2.gameObject.SetActive(true);
                counter1 = 2;
            }
            else
            {
                _help2.gameObject.SetActive(false);
                isOpen1 = false;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (!isOpen2)
            {
                _help3.gameObject.SetActive(true);
                counter2 = 1;
                isOpen2 = true;
            }
            else if (counter2 == 1)
            {
                _help3.gameObject.SetActive(false);
                _help4.gameObject.SetActive(true);
                counter2 = 2;
            }
            else if (counter2 == 2)
            {
                _help4.gameObject.SetActive(false);
                _help5.gameObject.SetActive(true);
                counter2 = 3;
            }
            else
            {
                _help5.gameObject.SetActive(false);
                isOpen2 = false;
            }

        }
    }

}
