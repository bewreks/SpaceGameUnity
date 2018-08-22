using UnityEngine;

public class ShipMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuShip;
    [SerializeField] private GameObject _cancelButton;
    [SerializeField] private GameObject _delim;
    [SerializeField] private GameObject _upgradesContainer;
    [SerializeField] private DescriptionUI _descriptionUi;

    private Vector3 _startPosition = new Vector3(327, -155, 0);
    private Vector3 _startScale = new Vector3(1, 1, 1);
    private Vector3 _endPosition = new Vector3(36, 0, 0);
    private Vector3 _endScale = new Vector3(0.6f, 0.6f, 1);

    [SerializeField] private Part _selectedPart;

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
        _selectedPart = null;
        _descriptionUi.gameObject.SetActive(false);
        RefreshData();
    }

    //TODO: узнать как делать это красиво
    public void SelectElement(int id)
    {
        _selectedPart = PlayerController.Instance.GetPart(id);

        RefreshData();
    }

    private void RefreshData()
    {
        HideUpgrades();
        
        if (_selectedPart == null)
        {
            _descriptionUi.gameObject.SetActive(false);
            return;
        }

        _descriptionUi.SetElementData(_selectedPart);
        _descriptionUi.gameObject.SetActive(true);

        var i = 0;
        foreach (var upgrade in _selectedPart.Upgrades)
        {
            var item = UpgradeItemPool.current.GetObject();
            var upgradeUi = item.GetComponent<UpgradeUI>();
            upgradeUi.SetUpgradeData(upgrade);
            upgradeUi.OnClick += OnClick;
            var transform = item.GetComponent<RectTransform>();
            transform.anchoredPosition = new Vector2(0, i++ * -transform.sizeDelta.y);
            item.SetActive(true);
        }
    }

    private void OnClick(UpgradeController upgrade)
    {
        PlayerController.Instance.BuyUpgrade(_selectedPart.Type, upgrade);
        RefreshData();
    }

    private void HideUpgrades()
    {
        for (int i = 0; i < _upgradesContainer.transform.childCount; i++)
        {
            var item = _upgradesContainer.transform.GetChild(i).gameObject;
            var upgradeUi = item.GetComponent<UpgradeUI>();
            upgradeUi.OnClick = null;
            item.SetActive(false);
        }
    }
}