using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public static Player current;

	private int _hp;
	private int _score;

	public int Hp
	{
		get { return _hp; }
		set
		{
			_hp = value;
			GameEvents.current.HP_CHANGED(_hp);
		}
	}

	public int Score
	{
		get { return _score; }
		set
		{
			_score = value; 
			GameEvents.current.SCORE_CHANGED(_score);
		}
	}

	private void Awake()
	{
		if (!current)
		{
			current = this;
			_hp = 100;
			_score = 0;
		}
	}

	private void Start()
	{
		GameEvents.current.HP_CHANGE += i => Hp += i;
		GameEvents.current.SCORE_CHANGE += i => Score += i;
	}
}
