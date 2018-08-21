using System.Collections.Generic;
using System.Linq;

public abstract class MainManager<T, M> where M : IModel
{
    private Dictionary<int, T> _controllers;

    private bool _isInited;

    public void Init(IEnumerable<M> models)
    {
        if (_isInited)
        {
            return;
        }

        _isInited = true;
        
        _controllers = new Dictionary<int, T>();

        foreach (var model in models)
        {
            var controller = CreateControllerFromModel(model);
            if (controller != null)
            {
                _controllers.Add(model.Id, controller);                
            }
        }
    }
    
    public IEnumerable<T> GetControllers()
    {
        return _controllers?.Values.AsEnumerable();
    }

    public T GetController(int id)
    {
        var upgrade = default(T);
        _controllers?.TryGetValue(id, out upgrade);
        return upgrade;
    }

    public abstract T CreateControllerFromModel(M model);
}