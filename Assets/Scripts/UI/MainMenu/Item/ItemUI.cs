using System;
using UnityEngine;

public abstract class ItemUI<T> : MonoBehaviour
{
        
    protected T _controller;
    public Action<T> OnClick;

    public void SetController(T controller)
    {
        _controller = controller;
        OnSetController();
    }

    public void Click()
    {
        OnClick?.Invoke(_controller);
    }

    public void Hide()
    {
        OnClick = null;
        gameObject.SetActive(false);
        OnHide();
    }

    public void Show(int pos)
    {
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, pos * -rectTransform.sizeDelta.y);
        rectTransform.localScale = Vector3.one;
        gameObject.SetActive(true);
        OnShow();
    }

    protected abstract void OnSetController();
    protected abstract void OnShow();
    protected abstract void OnHide();
}