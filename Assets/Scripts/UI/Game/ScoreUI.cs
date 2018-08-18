using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

	private Text _text;
	
	private void Awake()
	{
		_text = GetComponent<Text>();
	}

	void Start () {
		ScoreChanged(PlayerManager.current.Score);
		GameEvents.current.SCORE_CHANGED += ScoreChanged;
	}

	private void ScoreChanged(int score)
	{
		_text.text = score.ToString();
	}
}
