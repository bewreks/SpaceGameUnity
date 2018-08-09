using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShipMover : MonoBehaviour
{
    [SerializeField] private Vector2 _speed = new Vector2(10, 10);
    [SerializeField] private Rect _bounds = new Rect(0, 0, .6f, .6f);
    private Rect _screenBounds;

    private Camera _camera;

    private Vector3 _prevMousePosition;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        _screenBounds = _bounds;
        _screenBounds.x *= Screen.width;
        _screenBounds.y *= Screen.height;
        _screenBounds.height *= Screen.height;
        _screenBounds.width *= Screen.width;

        _screenBounds.min = _camera.ScreenToWorldPoint(_screenBounds.min);
        _screenBounds.max = _camera.ScreenToWorldPoint(_screenBounds.max);
    }

    private void Start()
    {
        _prevMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _prevMousePosition.x = Mathf.Clamp(_prevMousePosition.x, _screenBounds.min.x, _screenBounds.max.x);
        _prevMousePosition.y = Mathf.Clamp(_prevMousePosition.y, _screenBounds.min.y, _screenBounds.max.y);
        _prevMousePosition.z = 0;
        transform.position = _prevMousePosition;
    }

    void Update()
    {
        #region Mouse Positon
            var curMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var mouseDelta = curMousePosition - _prevMousePosition;
            _prevMousePosition = curMousePosition;
        #endregion

        #region Axis Position
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            var axisDelta = new Vector3(h * _speed.x * Time.deltaTime, v * _speed.y * Time.deltaTime);
        #endregion
        
        var position = transform.position + mouseDelta + axisDelta;
        position.x = Mathf.Clamp(position.x, _screenBounds.min.x, _screenBounds.max.x);
        position.y = Mathf.Clamp(position.y, _screenBounds.min.y, _screenBounds.max.y);
        position.z = 0;
        transform.position = position;
    }
}