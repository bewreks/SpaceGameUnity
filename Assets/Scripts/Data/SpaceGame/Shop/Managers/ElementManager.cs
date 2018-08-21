using System.Collections.Generic;
using System.Linq;

public class ElementManager : MainManager<ElementController, ElementModel>
{
    private static ElementManager _instance;

    public static ElementManager Instance => _instance ?? (_instance = new ElementManager());
    
    public override ElementController CreateControllerFromModel(ElementModel model)
    {
        return new ElementController(model);
    }
}