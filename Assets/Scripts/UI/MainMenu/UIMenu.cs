using UnityEngine;

public abstract class UIMenu : MonoBehaviour
{
    private int _id = -1;
    
    public void Show(int id)
    {
        if (_id != id)
        {
            OnShow();
            _id = id;
        }

    }
    
    public void Hide(int id)
    {
        if (_id != id)
        {
            OnHide();
            _id = -1;
        }
    }

    protected abstract void OnShow();
    protected abstract void OnHide();
}