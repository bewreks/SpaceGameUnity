using System;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : ItemUI<MissionController>
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _description;
    [SerializeField] private Text _price;

    protected override void OnSetController()
    {
        _name.text = _controller.Name;
        _description.text = _controller.Description;
        _price.text = _controller.Price.ToString();
    }

    protected override void OnShow()
    {
    }

    protected override void OnHide()
    {
    }
}