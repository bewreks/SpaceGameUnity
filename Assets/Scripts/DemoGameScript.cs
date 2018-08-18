using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGameScript : MonoBehaviour {

	[SerializeField][Range(0.001f, 200)] private float _asteriodRate = 1;
	
	private void Start()
	{
		Cursor.visible = false;
		GameEvents.current.SCORE_CHANGED += ScoreChanged;
		StartCoroutine(ThrowObject());
	}

	private void ScoreChanged(int score)
	{
		if (score % 300 == 0)
		{
			_asteriodRate++;
		}
	}

	private IEnumerator ThrowObject()
	{
		var transformPosition = new Vector3(25, Random.Range(-5.0f, 5.0f), 1);
		var isMedic = Random.Range(0, 4) % 4 == 0;
		GameObject obj;
		if (isMedic)
		{
			obj = MedKitPool.current.GetObject();
		}
		else
		{
			obj = AsteroidPool.current.GetObject();
			var scale = Random.Range(0.3f, 1);
			obj.transform.localScale = Vector3.one * scale;
			obj.GetComponent<GameObjectMover>().Speed = Random.Range(-6, -3);
		}
		obj.transform.position = transformPosition;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);
		yield return new WaitForSeconds(1 / _asteriodRate);
		StartCoroutine(ThrowObject());
	}

	public void Stop()
	{
		StopCoroutine(ThrowObject());
	}
}
