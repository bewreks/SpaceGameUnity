using System;
using System.Collections.Generic;

[Serializable]
public class ElementController
{
    private readonly ElementModel _model;
    private List<UpdateController> _updates;
    public Func<int, bool> OnBuy;

    public ElementController(ElementModel model)
    {
        _model = model;
    }

    public int Id => _model.id;
    public string Name => _model.name;
    public string Description => _model.description;

    public List<UpdateController> Updates
    {
        get
        {
            if (_updates == null)
            {
                _updates = new List<UpdateController>();
                if (_model.updates != null)
                {
                    foreach (var updateId in _model.updates)
                    {
                        var update = UpdateManager.GetUpdate(updateId);
                        if (update != null)
                        {
                            _updates.Add(update);
                        }
                    }
                }
            }
            _updates.Sort(Comparison);

            return _updates;
        }
    }

    private int Comparison(UpdateController x, UpdateController y)
    {
        return x.Group.CompareTo(y.Group);
    }

    public bool BuyUpdate(UpdateController update)
    {
        if (Updates.Contains(update) && OnBuy != null && OnBuy(update.Price))
        {
            _updates.Remove(update);
            _updates.AddRange(update.NextUpdates);
            return true;
        }

        return false;
    }
}