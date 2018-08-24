using UnityEngine;
using UnityEngine.UI;

public class ShipMenu : UIMenu
{
    [SerializeField] private ShipInteractive _shipInteractive;
    [SerializeField] private GameObject _cancelButton;
    [SerializeField] private GameObject _delim;
    [SerializeField] private GameObject _upgradesContainer;
    [SerializeField] private DescriptionUI _descriptionUi;
    [SerializeField] private Text _money;

    [SerializeField] private Part _selectedPart;

    private bool _minimized = true;

    public void MinimizeShip()
    {
        if (_minimized)
        {
            return;
        }
        _minimized = true;
        _shipInteractive.Minimize();
        _cancelButton.SetActive(true);
        _delim.SetActive(true);
        UpdateMoney();
    }

    public void MaximizeShip()
    {
        if (!_minimized)
        {
            return;
        }
        _minimized = false;
        _shipInteractive.Maximize();
        _cancelButton.SetActive(false);
        _delim.SetActive(false);
        _selectedPart = null;
        _descriptionUi.Hide();
        RefreshData();
        UpdateMoney();
    }

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
            _descriptionUi.Hide();
            return;
        }

        _descriptionUi.Show(_selectedPart);

        var i = 0;
        foreach (var upgrade in _selectedPart.Upgrades)
        {
            var item = PoolManager.GetObject(PoolsEnum.UPGRADE_ITEM);
            var upgradeUi = item.GetComponent<UpgradeUI>();
            upgradeUi.SetController(upgrade);
            upgradeUi.OnClick += OnClick;
            upgradeUi.Show(i++);
        }
    }

    private void OnClick(UpgradeController upgrade)
    {
        PlayerController.Instance.BuyUpgrade(_selectedPart.Type, upgrade);
        UpdateMoney();
        RefreshData();
    }

    private void HideUpgrades()
    {
        for (int i = 0; i < _upgradesContainer.transform.childCount; i++)
        {
            var item = _upgradesContainer.transform.GetChild(i).gameObject;
            var upgradeUi = item.GetComponent<UpgradeUI>();
            upgradeUi.Hide();
        }
    }

    private void UpdateMoney()
    {
        _money.text = $"У вас ${PlayerController.Instance.Money}";
    }

    protected override void OnShow()
    {
        PoolManager.UpdateParent(PoolsEnum.UPGRADE_ITEM, _upgradesContainer.transform);
        gameObject.SetActive(true);
        MaximizeShip();
    }

    protected override void OnHide()
    {
        gameObject.SetActive(false);
    }
}