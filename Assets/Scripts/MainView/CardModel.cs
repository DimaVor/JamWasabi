using TMPro;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _company;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _profession;
    [SerializeField] private TextMeshProUGUI _id;
    [SerializeField] private TextMeshProUGUI _lastDate;


    public void ShowCard(string company, string name, string profession, int id, string lastDate)
    {
        _company.text = company;
        _name.text = name;
        _profession.text = profession;
        _id.text = "ID:" + id.ToString();
        _lastDate.text = "Действует до: " + lastDate;

        gameObject.SetActive(true);
    }

    public void HideCard() => gameObject.SetActive(false);
    

}
