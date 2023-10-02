using UnityEngine.EventSystems;
using Zenject;

public class DragPhone : DragItem
{
    [Inject]
    private PcController _pcController;
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (_rectTransform.parent.GetComponent<Slot>() != null)
        {
            _pcController.HidePhone();
        }
        base.OnBeginDrag(eventData);


    }
}