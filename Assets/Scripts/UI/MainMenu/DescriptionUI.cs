using UnityEngine;
using UnityEngine.UI;

public class DescriptionUI : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _description;
    [SerializeField] private Text _values;

    public void Show(Part part)
    {
        SetPartData(part);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    private void SetPartData(Part part)
    {
        _name.text = part.Name;
        _description.text = part.Description;
        var values = "";
        switch (part.Type)
        {
            case PartTypes.GUN1:
            case PartTypes.GUN2:
            case PartTypes.GUN3:
            case PartTypes.GUN4:
            case PartTypes.GUN5:
                values = $"Скорострельность: {part.Power}";
                break;
            case PartTypes.SHIELD:
                values = $"Количество срабатываний: {part.Power} \r\n" +
                         $"Время восстановления: {part.CoolDown} c \r\n" +
                         $"Поглащение урона: {part.Resist}%";
                break;
            default:
                values = "Если вы это видите, то я где-то ошибся";
                break;
        }

        _values.text = values;
    }

}