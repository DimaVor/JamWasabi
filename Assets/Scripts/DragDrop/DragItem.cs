using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    protected RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Canvas _canvas;


    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = FindObjectOfType<Canvas>();
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;

        if(_rectTransform.parent.GetComponent<Slot>() != null)
        {
            _rectTransform.SetParent(_rectTransform.parent.parent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
    }
}
