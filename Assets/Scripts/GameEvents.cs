using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {

	public static GameEvents current;

	public Action<int> HP_CHANGED = i => { };
	public Action<int> SCORE_CHANGED = i => { };

	private void Awake()
	{
		current = this;
	}
}
