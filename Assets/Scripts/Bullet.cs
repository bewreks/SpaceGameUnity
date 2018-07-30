using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float _speed = 30;
	[SerializeField] private float _lifeTime = 2;

	private void OnEnable()
	{
		Invoke("Remove", _lifeTime);
	}

	private void FixedUpdate()
	{
		transform.Translate(_speed * Time.fixedDeltaTime, 0, 0);
	}

	private void Remove()
	{
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		CancelInvoke("Remove");
	}
}
