using UnityEngine;

public class Asteroid : MonoBehaviour {
	
	[SerializeField] private float _lifeTime = 2;

	private AsteroidController _controller;

	private void OnEnable()
	{
		Invoke("Remove", _lifeTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Bullet":
				var bullet = other.GetComponent<Bullet>();
				_controller.DoDamage(bullet.Damage);
				bullet.Hit();
				break;
			case "Player":
				_controller.Suicide();
				break;
		}

		if (!_controller.IsAlive)
		{
			Remove();
		}
	}

	private void Remove()
	{
		gameObject.SetActive(false);
		var explosion = PoolManager.GetObject(PoolsEnum.EXPLOSION);
		explosion.transform.position = transform.position;
		explosion.transform.rotation = transform.rotation;
		explosion.SetActive(true);
	}

	private void OnDisable()
	{
		CancelInvoke("Remove");
	}

	public void SetController(AsteroidController controller, Quaternion rotation)
	{
		_controller = controller;
		_controller.OnKill += OnKill;
		
		transform.localScale = Vector3.one * _controller.Radius;
		GetComponent<GameObjectMover>().Speed = _controller.Speed;
		var transformPosition = new Vector3(_controller.X, _controller.Y, _controller.Z);
		transform.position = transformPosition;
		transform.rotation = rotation;
		gameObject.SetActive(true);

	}

	private void OnKill(AsteroidController obj)
	{
		if (_controller.IsSuicide)
		{
			GameEvents.current.HP_CHANGE(-_controller.Damage);
		}
		else
		{
			GameEvents.current.SCORE_CHANGE(_controller.Score);
		}
	}
}
