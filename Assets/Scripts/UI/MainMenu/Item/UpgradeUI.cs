using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : ItemUI<UpgradeController>
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _description;
    [SerializeField] private Text _price;

    protected override void OnSetController()
    {
        _name.text = _controller.Name;
        _description.text = _controller.Description;
        switch (_controller.Type)
        {
            case UpgradeTypes.AddShield:
            case UpgradeTypes.IncreaseGunRotate:
            case UpgradeTypes.IncreaseShieldDamageResist:
            case UpgradeTypes.ReduceShieldCoolDown:
            case UpgradeTypes.IncreaseShieldPower:
                _description.text += " (заглушка, не работает)";
                break;
        }

        _price.text = _controller.Price.ToString();
    }

    protected override void OnShow()
    {
    }

    protected override void OnHide()
    {
    }
}