using UnityEngine;

public class ShipInteractive : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition = new Vector3(327, -155, 0);
    [SerializeField] private Vector3 _startScale = new Vector3(1, 1, 1);
    [SerializeField] private Vector3 _endPosition = new Vector3(36, 0, 0);
    [SerializeField] private Vector3 _endScale = new Vector3(0.6f, 0.6f, 1);

    private RectTransform _rectTransform;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Minimize()
    {
        _rectTransform.localScale = _endScale;
        _rectTransform.anchoredPosition = _endPosition;
    }

    public void Maximize()
    {
        _rectTransform.localScale = _startScale;
        _rectTransform.anchoredPosition = _startPosition;
    }
}