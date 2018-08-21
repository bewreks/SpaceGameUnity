using System;
using System.Collections.Generic;

public enum PartTypes
{
    ERROR = -1,
    GUN1 = 0,
    GUN2 = 1,
    GUN3 = 2,
    GUN4 = 3,
    GUN5 = 4,
    SHIELD = 5
}

public class Part
{
    private readonly ElementController _element;
    private PartTypes _type = PartTypes.ERROR;
    private int _power;
    private int _rotation;
    private int _cooldown;
    private int _resist;

    private int _tempPower;

    private List<UpgradeController> _upgrades;

    public Action OnApllyUpgrade;
    public Action OnApllyUpgradeError;

    public PartTypes Type => _type;
    public string Name => _element.Name;
    public string Description => _element.Description;
    public List<UpgradeController> Upgrades => _upgrades;

    // Общий
    public int Power => _power + _tempPower;

    // Для пушки
    public int Rotation => _rotation;

    // Для щита
    public int CoolDown => _cooldown;
    public int Resist => _resist;


    public Part(BoughtModel upgrade)
    {
        _type = (PartTypes) upgrade.elementtype;
        _element = ElementManager.Instance.GetController(upgrade.elementid);
        _upgrades = new List<UpgradeController>(_element.Upgrades);

        var boughtUpgrades = upgrade.upgrades ?? new int[0];
        foreach (var upgradeId in boughtUpgrades)
        {
            var upgradeController = UpgradeManager.Instance.GetController(upgradeId);
            ApplyUpgrade(upgradeController);
        }
    }

    public void ApplyUpgrade(UpgradeController upgrade)
    {
        if (_upgrades.Contains(upgrade))
        {
            switch (upgrade.Type)
            {
                case UpgradeTypes.AddShield:
                    _power = 1;
                    _cooldown = 10;
                    _resist = 10;
                    break;
                case UpgradeTypes.IncreaseGunRotate:
                    _rotation += upgrade.Value;
                    break;
                case UpgradeTypes.IncreaseShieldDamageResist:
                    _resist += upgrade.Value;
                    break;
                case UpgradeTypes.IncreaseShieldPower:
                    _power += upgrade.Value;
                    break;
                case UpgradeTypes.IncreaseShootRate:
                    _power += upgrade.Value;
                    break;
                case UpgradeTypes.ReduceShieldCoolDown:
                    _cooldown -= upgrade.Value;
                    break;
            }

            _upgrades.Remove(upgrade);
            _upgrades.AddRange(upgrade.NextUpgrades);
            _upgrades.Sort(Comparison);
            OnApllyUpgrade?.Invoke();
        }
        else
        {
            OnApllyUpgradeError?.Invoke();
        }
    }

    private int Comparison(UpgradeController x, UpgradeController y)
    {
        return x.Group.CompareTo(y.Group);
    }

    public void AddTempPower(int power)
    {
        _tempPower += power;
    }

    public void ResetTemp()
    {
        _tempPower = 0;
    }
}