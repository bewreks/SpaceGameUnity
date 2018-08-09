using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField][Range(0.001f, 200)] private float _shootRate;

	private void Start()
	{
		GameEvents.current.SCORE_CHANGED += ScoreChanged;
		StartCoroutine(Shoot());
	}

	private void ScoreChanged(int score)
	{
		if (score % 500 == 0)
		{
			_shootRate++;
		}
	}

	private IEnumerator Shoot()
	{
		var transformPosition = transform.position;
		transformPosition.z = 1;
		var bullet = BulletPool.current.GetObject();
		bullet.transform.position = transformPosition;
		bullet.transform.rotation = transform.rotation;
		bullet.SetActive(true);
		yield return new WaitForSeconds(1 / _shootRate);
		StartCoroutine(Shoot());
	}

	public void Stop()
	{
		StopCoroutine(Shoot());
	}
}
