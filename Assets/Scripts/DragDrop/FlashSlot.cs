using UnityEngine;

public class FlashSlot : Slot
{
    protected override bool CheckClass(GameObject pointerDrag) => pointerDrag.GetComponent<DragFlash>() != null;
}
