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

	public bool BuyItem(Item item)
	{
		return false;
	}
}

public class Item
{
	private int _cost;
	private string _name;
	private string _description;

	public int Cost => _cost;
	public string Name => _name;
	public string Description => _description;
	
}

