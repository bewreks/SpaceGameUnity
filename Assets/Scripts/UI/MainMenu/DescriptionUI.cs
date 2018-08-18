using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionUI : MonoBehaviour
{
	[SerializeField] private Text _name;
	[SerializeField] private Text _description;

	public void SetElementData(ElementController element)
	{
		_name.text = element.Name;
		_description.text = element.Description;
	}

}
