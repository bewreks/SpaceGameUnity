using System.Collections.Generic;

public class UpdateController
{
    public enum UpdateTypes
    {
        IncreaseShootRate = 1,
        IncreaseGunRotate = 2,
        AddShield = 3,
        IncreaseShieldDamageResist = 4,
        IncreaseShieldPower = 5,
        ReduceShieldCoolDown = 6
    }
        
    private readonly UpdateModel _model;
    private List<UpdateController> _nextUpdates;

    public UpdateController(UpdateModel model)
    {
        _model = model;
            
    }

    public int Id => _model.id;
    public int Price => _model.price;
    public int Group => _model.group;
    public UpdateTypes Type => (UpdateTypes)_model.updatetype;
    public int Value => _model.updatevalue;
    public string Name => _model.name;
    public string Description => _model.description;
    public List<UpdateController> NextUpdates
    {
        get
        {
            if (_nextUpdates == null)
            {
                _nextUpdates = new List<UpdateController>();
                if (_model.nextupdates != null)
                {
                    foreach (var nextId in _model.nextupdates)
                    {
                        var nextUpdate = UpdateManager.GetUpdate(nextId);
                        if (nextUpdate != null)
                            _nextUpdates.Add(nextUpdate);
                    }
                }
            }   
            return _nextUpdates;
        }
    }
}