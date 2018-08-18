using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour {
	[SerializeField] private float _lifeTime = 2;
	[SerializeField] private int _heal = 10;
	[SerializeField] private int _score = 100;

	private void OnEnable()
	{
		Invoke("Remove", _lifeTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Player":
				Remove();
				GameEvents.current.HP_CHANGE(_heal);
				GameEvents.current.SCORE_CHANGE(_score);
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
