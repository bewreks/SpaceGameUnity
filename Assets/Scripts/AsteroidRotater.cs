using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotater : MonoBehaviour
{
	[SerializeField] private Vector3 _rotation;
	
	private void Awake()
	{
		_rotation = new Vector3(0, 0, Random.Range(-4, 4));
	}

	private void FixedUpdate()
	{
		transform.Rotate(_rotation);
	}
}
