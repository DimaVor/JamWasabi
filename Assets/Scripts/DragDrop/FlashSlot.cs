using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class FlashSlot : Slot
{
    [SerializeField] private TextMeshProUGUI _files;
    [Inject]
    private PcController _pcController;
    protected override bool CheckClass(GameObject pointerDrag) => pointerDrag.GetComponent<DragFlash>() != null;

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        if (eventData.pointerDrag != null && CheckClass(eventData.pointerDrag))
        {
            string files = string.Join("\n", eventData.pointerDrag.GetComponent<DragFlash>().Model.GetFiles());
            _files.text = files;
            _pcController.ShowFlash();
        }
    }
}
