using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShip : MonoBehaviour
{
	[SerializeField] private GameObject[] _guns;
	[SerializeField] private GameObject _explosion;
	
	void Start ()
	{
		GameEvents.current.PLAYER_DEAD += OnPlayerDead;
		Instantiate(_guns[PlayerManager.current.Gun], transform);
	}

	private void OnPlayerDead()
	{
		gameObject.SetActive(false);
		Instantiate(_explosion, transform.position, transform.rotation);
	}
}
