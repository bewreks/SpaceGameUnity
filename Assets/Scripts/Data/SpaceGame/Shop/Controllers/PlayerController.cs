using System.Collections.Generic;
using System.Linq;

public class PlayerController
{
    private static PlayerController _instance;

    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerController();
            }

            return _instance;
        }
    }

    private PlayerModel _model;
    private List<ElementController> _elements;

    private Dictionary<PartTypes, Part> _parts;

    private MissionController _currentMission;

    private bool _isInited;

    public int Id => _model.id;
    public int Money => _model.money;
    public string Name => _model.name;
    public MissionController CurrentMission => _currentMission;

    public Part GetPart(PartTypes id)
    {
        Part element = null;
        _parts?.TryGetValue(id, out element);
        return element;
    }

    public Part GetPart(int partId)
    {
        return GetPart((PartTypes) partId);
    }

    public IEnumerable<Part> GetParts()
    {
        return _parts?.Values.AsEnumerable() ?? new List<Part>();
    }

    public void Init(PlayerModel playerModel, IEnumerable<BoughtModel> upgrades)
    {
        if (_isInited)
        {
            return;
        }

        _isInited = true;
        
        _model = playerModel;
        _parts = new Dictionary<PartTypes, Part>();
        foreach (var bought in upgrades)
        {
            var gun = new Part(bought);
            _parts.Add(gun.Type, gun);
        }
    }

    public bool HasMoney(int needMoney)
    {
        return Money >= needMoney;
    }

    public void AddMoney(int money)
    {
        _model.money += money;
    }

    public bool BuyUpgrade(PartTypes type, UpgradeController upgrade)
    {
        if (HasMoney(upgrade.Price))
        {
            _model.money -= upgrade.Price;
            GetPart(type).ApplyUpgrade(upgrade);
            return true;
        }

        return false;
    }

    public void SelectMission(MissionController mission)
    {
        _currentMission = mission;
    }

    public void ResetTempData()
    {
        foreach (var part in GetParts())
        {
            part.ResetTemp();
        }
    }
}