using System;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _description;
    [SerializeField] private Text _price;

    private MissionController _mission;
    public Action<MissionController> OnClick;

    public void SetMissionData(MissionController mission)
    {
        _mission = mission;
        _name.text = _mission.Name;
        _description.text = _mission.Description;
        _price.text = _mission.Price.ToString();
    }

    public void Click()
    {
        OnClick?.Invoke(_mission);
    }
}