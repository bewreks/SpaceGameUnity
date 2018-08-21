using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShipMover : MonoBehaviour
{
    [SerializeField] private Vector2 _speed = new Vector2(10, 10);
    [SerializeField] private Rect _bounds = new Rect(0, 0, .6f, .6f);
    [SerializeField] private ParticleSystem _flame;
    private Rect _screenBounds;

    private Camera _camera;

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
        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, _screenBounds.min.x, _screenBounds.max.x);
        mousePosition.y = Mathf.Clamp(mousePosition.y, _screenBounds.min.y, _screenBounds.max.y);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    void Update()
    {
        #region Mouse Positon
            var x = Input.GetAxis("Mouse X");
            var y = Input.GetAxis("Mouse Y");
            var mouseDelta = new Vector3(x * _speed.x * Time.deltaTime, y * _speed.y * Time.deltaTime);
        #endregion

        #region Axis Position
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            var axisDelta = new Vector3(h * _speed.x * Time.deltaTime, v * _speed.y * Time.deltaTime);
        #endregion

        var shapeModule = _flame.shape;
        var t = mouseDelta.x + axisDelta.x;
        if (t < 0)
        {
            t = -1;
        }
        else
        {
            t = t > 0 ? 1 : 0;
        }
        var shapeModuleAngle = Mathf.LerpUnclamped(30, 0, t);
        shapeModule.angle = shapeModuleAngle;
        
        var position = transform.position + mouseDelta + axisDelta;
        position.x = Mathf.Clamp(position.x, _screenBounds.min.x, _screenBounds.max.x);
        position.y = Mathf.Clamp(position.y, _screenBounds.min.y, _screenBounds.max.y);
        position.z = 0;
        
        if (!Pauser.current.Paused)
        {
            transform.position = position;
        }
    }
}