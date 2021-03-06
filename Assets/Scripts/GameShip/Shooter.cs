﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField][Range(0.001f, 200)] private float _shootRate;
	[SerializeField] private PartTypes _type;

	private void Start()
	{
		_shootRate = PlayerController.Instance.GetPart(_type).Power;
		if (_shootRate != 0)
		{
			StartCoroutine(Shoot());
		}
	}

	private IEnumerator Shoot()
	{
		_shootRate = PlayerController.Instance.GetPart(_type).Power;
		var transformPosition = transform.position;
		transformPosition.z = -0.5f;
		var result = PoolManager.GetObject(PoolsEnum.BULLET);
		result.transform.position = transformPosition;
		result.transform.rotation = transform.rotation;
		result.SetActive(true);
		yield return new WaitForSeconds(1 / _shootRate);
		StartCoroutine(Shoot());
	}

	public void Stop()
	{
		StopCoroutine(Shoot());
	}
}
