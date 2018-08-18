using UnityEngine;

public class Asteroid : MonoBehaviour {

	struct AsteroidData
	{
		public float hp;
	}
	
	[SerializeField] private float _lifeTime = 2;
	[SerializeField] private int _damage;
	[SerializeField] private int _hp;
	[SerializeField] private int _score;
	[SerializeField] private GameObject _explosion;

	private AsteroidData _data;

	private void OnEnable()
	{
		_data.hp = _hp;
		Invoke("Remove", _lifeTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Bullet":
				var bullet = other.GetComponent<Bullet>();
				_data.hp -= bullet.Damage;
				GameEvents.current.SCORE_CHANGE(_score);
				bullet.Hit();
				break;
			case "Player":
				_data.hp = 0;
				GameEvents.current.HP_CHANGE(-_damage);
				break;
		}

		if (_data.hp <= 0)
		{
			Remove();
		}
	}

	private void Remove()
	{
		gameObject.SetActive(false);
		Instantiate(_explosion, transform.position, transform.rotation);
	}

	private void OnDisable()
	{
		CancelInvoke("Remove");
	}
}
