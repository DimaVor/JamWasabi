using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PhoneGenerator : MonoBehaviour
{
    [SerializeField] private List<Image> _images = new();

    [SerializeField] private List<Sprite> _goodIcons = new();
    [SerializeField] private List<Sprite> _badIcons = new();
    [SerializeField] private int _badIconPrecentage;

    [Space]
    [SerializeField]
    private List<string> _viruses = new(){
            "WannaCry",
            "Stuxnet",
            "Conficker",
            "ILOVEYOU",
            "Mydoom",
            "Code Red",
            "Sasser",
            "Slammer",
            "Nimda",
            "Zeus"
        };
    [SerializeField] private int _virusesPrecentage;

    public bool GenerateImages()
    {
        List<Sprite> icons = new(_goodIcons);
        foreach(var image in _images)
        {
            int index = Random.Range(0, icons.Count);
            image.sprite = icons[index];
            icons.RemoveAt(index);
        }

        bool isBadImage = false;
        int rand = Random.Range(0, 100);
        if(rand < _badIconPrecentage)
        {
            isBadImage = true;
            _images[Random.Range(0, _images.Count)].sprite = _badIcons[Random.Range(0, _badIcons.Count)];
        }
        return isBadImage;
    }

    public bool GenerateVirus(out string virus)
    {
        virus = "Вирусы:\nНе обнаружено!";
        bool isVirus = false;
        int rand = Random.Range(0, 100);
        if (rand < _virusesPrecentage)
        {
            isVirus = true;
            virus = "Вирусы:\n"+ "<color=#" + ColorUtility.ToHtmlStringRGBA(UnityEngine.Color.red) + ">" + _viruses[Random.Range(0, _viruses.Count)] + "</color>";
        }
        return isVirus;
    }
}
