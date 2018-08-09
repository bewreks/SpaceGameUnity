using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour
{

	[SerializeField] private float _speed = 10;

	public float Speed
	{
		get { return _speed; }
		set { _speed = value; }
	}

	private void FixedUpdate()
	{
		transform.Translate(_speed * Time.fixedDeltaTime, 0, 0);
	}
}
