using UnityEngine;

public class DragFlash : DragItem
{
    private Flash _model;

    public void SetModel(Flash model)
    {
        _model = model;
    }
    public Flash Model => _model;
}
