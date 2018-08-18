using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

	[SerializeField] private Text _name;
	[SerializeField] private Text _description;
	[SerializeField] private Text _price;

	private UpdateController _update;
	public Action<UpdateController> OnClick;

	public void SetUpdateData(UpdateController update)
	{
		_update = update;
		_name.text = _update.Name;
		_description.text = _update.Description;
		_price.text = _update.Price.ToString();
	}

	public void Click()
	{
		OnClick?.Invoke(_update);
	}
}
