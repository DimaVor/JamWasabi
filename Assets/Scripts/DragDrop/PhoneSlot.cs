using UnityEngine;

public class PhoneSlot : Slot
{
    protected override bool CheckClass(GameObject pointerDrag) => pointerDrag.GetComponent<DragPhone>() != null;
}
