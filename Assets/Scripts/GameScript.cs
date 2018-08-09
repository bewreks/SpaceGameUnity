﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	[SerializeField][Range(0.001f, 200)] private float _asteriodRate = 1;
	
	private void Start()
	{
		Cursor.visible = false;
		GameEvents.current.SCORE_CHANGED += ScoreChanged;
		StartCoroutine(ThrowObject());
	}

	private void ScoreChanged(int score)
	{
		if (score % 300 == 0)
		{
			_asteriodRate++;
		}
	}

	private IEnumerator ThrowObject()
	{
		var transformPosition = new Vector3(25, Random.Range(-5.0f, 5.0f), 1);
		var asteroid = AsteroidPool.current.GetObject();
		asteroid.transform.position = transformPosition;
		asteroid.transform.rotation = transform.rotation;
		var scale = Random.Range(0.3f, 1);
		asteroid.transform.localScale = Vector3.one * scale;
		asteroid.GetComponent<AsteroidMover>().Speed = Random.Range(-6, -3);
		asteroid.SetActive(true);
		yield return new WaitForSeconds(1 / _asteriodRate);
		StartCoroutine(ThrowObject());
	}

	public void Stop()
	{
		StopCoroutine(ThrowObject());
	}

	private void Update()
	{
		if (Input.GetButton("Cancel"))
		{
			Application.Quit();
		}
	}
}
