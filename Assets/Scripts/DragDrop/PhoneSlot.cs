using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PhoneSlot : Slot
{
    [Inject]
    private PcController _pcController;
    protected override bool CheckClass(GameObject pointerDrag) => pointerDrag.GetComponent<DragPhone>() != null;

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        if (eventData.pointerDrag != null && CheckClass(eventData.pointerDrag))
        {
            _pcController.ShowPhone();
        }
    }
}
