using UnityEngine;

public class PlayerManager : MonoBehaviour
{

	public static PlayerManager current;

	[SerializeField] private GameObject _ship;
	[SerializeField] private int _maxHP = 1000;

	private int _hp;
	private int _score;
	
	public int Gun => 4;

	public int Hp
	{
		get { return _hp; }
		set
		{
			_hp = value;
			GameEvents.current.HP_CHANGED(_hp);
			if (_hp <= 0)
			{
				GameEvents.current.PLAYER_DEAD();
			}
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
		GameEvents.current.HP_CHANGE += i =>
		{
			Hp = Mathf.Min(Hp + i, _maxHP);
		};
		GameEvents.current.SCORE_CHANGE += i => Score += i;

		Instantiate(_ship);
	}
}
