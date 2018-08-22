using UnityEngine;

public class MedKit : MonoBehaviour {
	[SerializeField] private float _lifeTime = 2;

	private MedkitController _controller;

	private void OnEnable()
	{
		Invoke("Remove", _lifeTime);
	}

	public void SetController(MedkitController controller, Quaternion rotation)
	{
		_controller = controller;
		_controller.OnPickup += OnPickup;
		var transformPosition = new Vector3(_controller.X, _controller.Y, _controller.Z);
		transform.position = transformPosition;
		transform.rotation = rotation;
		gameObject.SetActive(true);
	}

	private void OnPickup(MedkitController objcontroller)
	{
		GameEvents.current.HP_CHANGE(_controller.Heal);
		GameEvents.current.SCORE_CHANGE(_controller.Score);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag)
		{
			case "Player":
				Remove();
				_controller.Pickup();
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
