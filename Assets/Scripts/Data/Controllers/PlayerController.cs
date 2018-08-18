using System.Collections.Generic;

public class PlayerController
{
    public enum ElementTypes
        {
            GUN1 = 0,
            GUN2 = 1,
            GUN3 = 2,
            GUN4 = 3,
            GUN5 = 4,
            SHIELD = 5
        }

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

        private Dictionary<ElementTypes, ElementController> _elementControllers;
        private Dictionary<ElementTypes, BoughtModel> _boughtModels;

        public int Id => _model.id;
        public int Money => _model.money;
        public string Name => _model.name;

        public ElementController GetElement(ElementTypes id)
        {
            ElementController element = null;
            _elementControllers?.TryGetValue(id, out element);
            return element;
        }

        public void Init(PlayerModel playerModel, IEnumerable<BoughtModel> updates)
        {
            _model = playerModel;
            _elementControllers = new Dictionary<ElementTypes, ElementController>();
            _boughtModels = new Dictionary<ElementTypes, BoughtModel>();
            foreach (var bought in updates)
            {
                _elementControllers.Add((ElementTypes)bought.elementtype, ElementManager.GetElement(bought.elementid));
                _boughtModels.Add((ElementTypes)bought.elementtype, bought);
            }
        }

        public bool HasMoney(int needMoney)
        {
            return Money >= needMoney;
        }

        public bool SpendMoney(int money)
        {
            if (HasMoney(money))
            {
                _model.money -= money;
                return true;
            }

            return false;
        }

        public void AddMoney(int money)
        {
            _model.money += money;
        }
}
