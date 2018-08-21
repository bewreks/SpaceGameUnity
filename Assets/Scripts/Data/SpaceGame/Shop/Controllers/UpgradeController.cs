using System.Collections.Generic;

public enum UpgradeTypes
{
    IncreaseShootRate = 1,
    IncreaseGunRotate = 2,
    AddShield = 3,
    IncreaseShieldDamageResist = 4,
    IncreaseShieldPower = 5,
    ReduceShieldCoolDown = 6
}

public class UpgradeController
{
    private readonly UpgradeModel _model;
    private List<UpgradeController> _nextUpgrades;

    public UpgradeController(UpgradeModel model)
    {
        _model = model;
    }

    public int Id => _model.id;
    public int Price => _model.price;
    public int Group => _model.group;
    public UpgradeTypes Type => (UpgradeTypes) _model.upgradetype;
    public int Value => _model.upgradevalue;
    public string Name => _model.name;
    public string Description => _model.description;

    public List<UpgradeController> NextUpgrades
    {
        get
        {
            if (_nextUpgrades == null)
            {
                _nextUpgrades = new List<UpgradeController>();
                if (_model.nextupgrades != null)
                {
                    foreach (var nextId in _model.nextupgrades)
                    {
                        var nextUpgrade = UpgradeManager.Instance.GetController(nextId);
                        if (nextUpgrade != null)
                            _nextUpgrades.Add(nextUpgrade);
                    }
                }
            }

            return _nextUpgrades;
        }
    }
}