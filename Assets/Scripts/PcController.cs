using TMPro;
using UnityEngine;

public class PcController : MonoBehaviour
{
    [SerializeField] private RectTransform _phoneCheck;
    [SerializeField] private TextMeshProUGUI _antivirusText;

    [SerializeField] private RectTransform _flashCheck;

    public void ShowPhone()
    {
        HideFlash();
        _phoneCheck.gameObject.SetActive(true);
    }

    public void HidePhone()
    {
        _phoneCheck.gameObject.SetActive(false);
        _antivirusText.gameObject.SetActive(false);
    }


    public void ShowFlash()
    {
        HidePhone();
        _flashCheck.gameObject.SetActive(true);
    }

    public void HideFlash()
    {
        _flashCheck.gameObject.SetActive(false);
    }
}
