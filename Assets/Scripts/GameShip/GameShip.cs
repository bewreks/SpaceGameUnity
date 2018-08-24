using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShip : MonoBehaviour
{
	[SerializeField] private GameObject[] _guns;
	
	void Start ()
	{
		GameEvents.current.PLAYER_DEAD += OnPlayerDead;
		Instantiate(_guns[PlayerManager.current.Gun], transform);
	}

	private void OnPlayerDead()
	{
		gameObject.SetActive(false);
		var explosion = PoolManager.GetObject(PoolsEnum.EXPLOSION);
		explosion.transform.position = transform.position;
		explosion.transform.rotation = transform.rotation;
		explosion.SetActive(true);
	}
}
