using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Slot : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    protected abstract bool CheckClass(GameObject pointerDrag);

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && CheckClass(eventData.pointerDrag))
        {
            var rect = eventData.pointerDrag.GetComponent<RectTransform>();
            rect.anchoredPosition = _rectTransform.anchoredPosition;
            rect.SetParent(transform, true);
        }
    }
}