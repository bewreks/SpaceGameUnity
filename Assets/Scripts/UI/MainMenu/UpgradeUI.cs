using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _description;
    [SerializeField] private Text _price;

    private UpgradeController _upgrade;
    public Action<UpgradeController> OnClick;

    public void SetUpgradeData(UpgradeController update)
    {
        _upgrade = update;
        _name.text = _upgrade.Name;
        _description.text = _upgrade.Description;
        switch (update.Type)
        {
            case UpgradeTypes.AddShield:
            case UpgradeTypes.IncreaseGunRotate:
            case UpgradeTypes.IncreaseShieldDamageResist:
            case UpgradeTypes.ReduceShieldCoolDown:
            case UpgradeTypes.IncreaseShieldPower:
                _description.text += " (заглушка, не работает)";
                break;
        }

        _price.text = _upgrade.Price.ToString();
    }

    public void Click()
    {
        OnClick?.Invoke(_upgrade);
    }
}