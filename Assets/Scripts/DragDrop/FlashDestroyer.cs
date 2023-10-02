using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class FlashDestroyer : Slot
{
    [SerializeField] private float _destroySanction;
    [SerializeField] private float _destroyBonus;

    [Inject]
    private StatesController _statesController;
    protected override bool CheckClass(GameObject pointerDrag) => pointerDrag.GetComponent<DragFlash>() != null;

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && CheckClass(eventData.pointerDrag))
        {
            if (eventData.pointerDrag.GetComponent<DragFlash>().Model.GetNumOfBadFiles() == 0)
            {
                _statesController.DecreaseValue(States.Happiness, _destroySanction);
            }
            else
            {
                _statesController.IncreaseValue(States.Cybersec, _destroyBonus);
            }
            Destroy(eventData.pointerDrag.gameObject);
        }
    }
}
