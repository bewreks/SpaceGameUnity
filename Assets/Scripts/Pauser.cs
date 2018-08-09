using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
	[SerializeField] private Canvas _pauseUI;
	[SerializeField] private Canvas _gameUI;
	
	public static Pauser current;

	private bool _paused;
	private bool _clicked;
	
	public bool Paused => _paused;

	private void Awake()
	{
		current = this;
	}

	private void Start()
	{
		_clicked = false;
		Resume();
	}

	void Update ()
	{
		
		if (Input.GetButtonDown("Cancel"))
		{
			if (!_clicked) 
			if (Paused)
			{
				Resume();
			}
			else
			{
				Pause();
			}

			_clicked = true;
		}

		if (Input.GetButtonUp("Cancel"))
		{
			_clicked = false;
		}
		
	}

	public void Pause()
	{
		Cursor.visible = true;
		_pauseUI.enabled = true;
		_gameUI.enabled = false;
		_paused = true;
		Time.timeScale = 0;
	}

	public void Resume()
	{
		Cursor.visible = false;
		_pauseUI.enabled = false;
		_gameUI.enabled = true;
		_paused = false;
		Time.timeScale = 1;
	}

	public void Exit()
	{
		Application.Quit();
	}
}
