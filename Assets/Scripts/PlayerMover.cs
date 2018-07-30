using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	[SerializeField] private Vector2 _speed = new Vector2(10, 10);
	[SerializeField] private Rect _bounds = new Rect(0, 0, .6f, .6f); 
	
	
	
	private Camera _camera;

	private void Awake()
	{
		_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	void Update ()
	{
		/*var mousePosition = Input.mousePosition;
		mousePosition.x = Mathf.Clamp(mousePosition.x, 0, Screen.width * 0.33f);
		mousePosition.y = Mathf.Clamp(mousePosition.y, 0, Screen.height);
		var screenToWorldPoint = _camera.ScreenToWorldPoint(mousePosition);
		screenToWorldPoint.x = transform.position.x;
		screenToWorldPoint.z = 0;
		transform.position = screenToWorldPoint;*/
	}

	private void FixedUpdate()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");
		var position = transform.position;
		position.x += h * _speed.x * Time.fixedDeltaTime;
		position.y += v * _speed.y * Time.fixedDeltaTime;

		var bounds = _bounds;
		bounds.x *= Screen.width;
		bounds.y *= Screen.height;
		bounds.height *= Screen.height;
		bounds.width *= Screen.width;

		bounds.min = _camera.ScreenToWorldPoint(bounds.min);
		bounds.max = _camera.ScreenToWorldPoint(bounds.max);
		
		position.x = Mathf.Clamp(position.x, bounds.min.x, bounds.max.x);
		position.y = Mathf.Clamp(position.y, bounds.min.y, bounds.max.y);
		transform.position = position;
	}
}
