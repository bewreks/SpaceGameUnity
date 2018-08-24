using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float _speed = 30;
	[SerializeField] private float _lifeTime = 2;
	[SerializeField] private float _damage;
	
	public float Damage => _damage;

	private void OnEnable()
	{
		Invoke("Remove", _lifeTime);
	}

	private void FixedUpdate()
	{
		transform.Translate(_speed * Time.fixedDeltaTime, 0, 0);
	}

	public void Remove()
	{
		GetComponent<PoolObject>().ReturnToPool();
	}

	private void OnDisable()
	{
		CancelInvoke("Remove");
	}

	public void Hit()
	{
		Remove();
	}
}
