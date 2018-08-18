using System.Collections.Generic;
using System.Linq;

public static class ElementManager
{
    private static Dictionary<int, ElementController> _elements;

    public static void Init(IEnumerable<ElementModel> elements)
    {
        _elements = new Dictionary<int, ElementController>();
        foreach (var element in elements)
        {
            var elementController = new ElementController(element);
            elementController.OnBuy = PlayerController.Instance.HasMoney;
            _elements.Add(element.id, elementController);
        }
    }


    public static IEnumerable<ElementController> GetElements()
    {
        return _elements?.Values.AsEnumerable();
        ;
    }

    public static ElementController GetElement(int id)
    {
        ElementController element = null;
        _elements?.TryGetValue(id, out element);
        return element;
    }
}