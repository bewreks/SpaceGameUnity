using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{

	public static Pool current;
	[SerializeField] private GameObject _pooledObject;
	[SerializeField] private GameObject _bulletsContainer;

	[SerializeField] private List<GameObject> _objects;
	
	private void Awake()
	{
		current = this;
	}

	private void Start () {
		_objects = new List<GameObject>();
	}

	public GameObject GetObject()
	{
		var gObject = (from o in _objects where !o.activeInHierarchy select o).FirstOrDefault();
		if (gObject == null)
		{
			gObject = Instantiate(_pooledObject, _bulletsContainer.transform);
			_objects.Add(gObject); 
		}

		return gObject;
	}
}
