using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	[SerializeField] private float _lifeTime = 2;

	private void OnEnable()
	{
		Invoke("Remove", _lifeTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Bullet":
				Remove();
				Player.current.Score += 100;
				other.GetComponent<Bullet>().Remove();
				break;
			case "Player":
				Remove();
				Player.current.Hp -= 10;
				break;
		}
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
