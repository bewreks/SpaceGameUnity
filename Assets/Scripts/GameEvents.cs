using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {

	public static GameEvents current;

	public Action<float> HP_CHANGED = i => { };
	public Action<int> SCORE_CHANGED = i => { };
	public Action<float> HP_CHANGE = i => { };
	public Action<int> SCORE_CHANGE = i => { };
	public Action 	   PLAYER_DEAD = () => { };

	private void Awake()
	{
		current = this;
	}
}
