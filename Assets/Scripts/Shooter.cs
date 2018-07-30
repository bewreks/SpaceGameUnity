using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField][Range(0.001f, 200)] private float _shootRate;

	private void Start()
	{
		StartCoroutine(Shoot());
	}

	private IEnumerator Shoot()
	{
		var transformPosition = transform.position;
		transformPosition.z = 1;
		var bullet = Pool.current.GetObject();
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
