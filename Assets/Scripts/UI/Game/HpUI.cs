﻿using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour {

	private Text _text;
	
	private void Awake()
	{
		_text = GetComponent<Text>();
	}

	void Start () {
		HpChanged(PlayerManager.current.Hp);
		GameEvents.current.HP_CHANGED += HpChanged;
	}

	private void HpChanged(float hp)
	{
		_text.text = Mathf.FloorToInt(hp).ToString();
	}
}
