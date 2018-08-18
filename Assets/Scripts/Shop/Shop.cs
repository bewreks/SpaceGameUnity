using UnityEngine;

public class Shop : MonoBehaviour
{

	public static Shop current;

	private void Awake()
	{
		if (!current)
		{
			current = this;
		}
	}
}

