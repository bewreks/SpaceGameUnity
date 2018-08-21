using UnityEngine;
using UnityEngine.UI;

public class DescriptionUI : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _description;
    [SerializeField] private Text _values;


    public void SetElementData(Part element)
    {
        _name.text = element.Name;
        _description.text = element.Description;
        var values = "";
        switch (element.Type)
        {
            case PartTypes.GUN1:
            case PartTypes.GUN2:
            case PartTypes.GUN3:
            case PartTypes.GUN4:
            case PartTypes.GUN5:
                values = $"Скорострельность: {element.Power}";
                break;
            case PartTypes.SHIELD:
                values = $"Количество срабатываний: {element.Power} \r\n" +
                         $"Время восстановления: {element.CoolDown} c \r\n" +
                         $"Поглащение урона: {element.Resist}%";
                break;
            default:
                values = "Если вы это видите, то я где-то ошибся";
                break;
        }

        _values.text = values;
    }
}