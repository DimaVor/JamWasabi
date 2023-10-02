using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRotator : MonoBehaviour
{
    private RectTransform _rectTransform;
    private float angle = 0;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        angle = (angle + Time.deltaTime) % 360;
        _rectTransform.rotation = Quaternion.EulerRotation(new Vector3(0, 0, -angle*3));
    }
}
