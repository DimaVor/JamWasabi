using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform)), RequireComponent(typeof(Button))]
public abstract class UIClicableItem : MonoBehaviour
{
    protected Button MButton;
    protected RectTransform MRoot;

    protected virtual void Awake()
    {
        MRoot = gameObject.GetComponent<RectTransform>();
        MButton = gameObject.GetComponent<Button>();
    }

    protected virtual void OnEnable()
    {
        Subscribe();
    }

    protected virtual void OnDisable()
    {
        UnSubscribe();
    }

    protected virtual void Subscribe()
    {
        MButton.onClick.AddListener(Click);
    }

    protected virtual void UnSubscribe()
    {
        MButton.onClick.RemoveAllListeners();
    }

    protected abstract void Click();




}