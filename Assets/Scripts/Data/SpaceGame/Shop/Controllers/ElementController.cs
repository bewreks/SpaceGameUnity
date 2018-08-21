using System.Collections.Generic;

public class ElementController
{
    private readonly ElementModel _model;
    private List<UpgradeController> _upgrades;

    public ElementController(ElementModel model)
    {
        _model = model;
    }

    public int Id => _model.id;
    public string Name => _model.name;
    public string Description => _model.description;

    public List<UpgradeController> Upgrades
    {
        get
        {
            if (_upgrades == null)
            {
                _upgrades = new List<UpgradeController>();
                if (_model.upgrades != null)
                {
                    foreach (var upgradeId in _model.upgrades)
                    {
                        var upgrade = UpgradeManager.Instance.GetController(upgradeId);
                        if (upgrade != null)
                        {
                            _upgrades.Add(upgrade);
                        }
                    }
                }
            }

            _upgrades.Sort(Comparison);

            return _upgrades;
        }
    }

    private int Comparison(UpgradeController x, UpgradeController y)
    {
        return x.Group.CompareTo(y.Group);
    }
}