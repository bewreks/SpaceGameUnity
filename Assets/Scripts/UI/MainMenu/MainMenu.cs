using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuShip;
    [SerializeField] private GameObject _cancelButton;
    [SerializeField] private GameObject _delim;
    [SerializeField] private GameObject _updatesContainer;
    [SerializeField] private DescriptionUI _descriptionUi;

    private Vector3 _startPosition = new Vector3(327, -155, 0);
    private Vector3 _startScale = new Vector3(1, 1, 1);
    private Vector3 _endPosition = new Vector3(36, 0, 0);
    private Vector3 _endScale = new Vector3(0.6f, 0.6f, 1);

    [SerializeField] private ElementController _selectedElement;

    private bool hided = true;

    private void Start()
    {
        ShowShip();
    }

    public void HideShip()
    {
        if (hided) return;
        hided = true;
        var rectTransform = _mainMenuShip.GetComponent<RectTransform>();
        rectTransform.localScale = _endScale;
        rectTransform.anchoredPosition = _endPosition;
        _cancelButton.SetActive(true);
        _delim.SetActive(true);
    }

    public void ShowShip()
    {
        if (!hided) return;
        hided = false;
        var rectTransform = _mainMenuShip.GetComponent<RectTransform>();
        rectTransform.localScale = _startScale;
        rectTransform.anchoredPosition = _startPosition;
        _cancelButton.SetActive(false);
        _delim.SetActive(false);
        _selectedElement = null;
        _descriptionUi.gameObject.SetActive(false);
        RefreshData();
    }

    //TODO: узнать как делать это красиво
    public void SelectElement(int id)
    {
        _selectedElement = PlayerController.Instance.GetElement((PlayerController.ElementTypes) id);

        RefreshData();
    }

    private void RefreshData()
    {
        HideUpdates();
        
        if (_selectedElement == null)
        {
            _descriptionUi.gameObject.SetActive(false);
            return;
        }

        _descriptionUi.SetElementData(_selectedElement);
        _descriptionUi.gameObject.SetActive(true);

        var i = 0;
        foreach (var update in _selectedElement.Updates)
        {
            var item = UpdateItemPool.current.GetObject();
            var updateUi = item.GetComponent<UpdateUI>();
            updateUi.SetUpdateData(update);
            updateUi.OnClick += OnClick;
            var transform = item.GetComponent<RectTransform>();
            transform.anchoredPosition = new Vector2(0, i++ * -transform.sizeDelta.y);
            item.SetActive(true);
        }
    }

    private void OnClick(UpdateController update)
    {
        _selectedElement.BuyUpdate(update);
        RefreshData();
    }

    private void HideUpdates()
    {
        for (int i = 0; i < _updatesContainer.transform.childCount; i++)
        {
            var item = _updatesContainer.transform.GetChild(i).gameObject;
            var updateUi = item.GetComponent<UpdateUI>();
            updateUi.OnClick = null;
            item.SetActive(false);
        }
    }
}