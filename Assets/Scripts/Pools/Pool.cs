using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Pool : MonoBehaviour
{

	[SerializeField] private GameObject _pooledObject;

	[SerializeField] private List<GameObject> _objects;

	private void Start () {
		_objects = new List<GameObject>();
	}

	public GameObject GetObject()
	{
		var gObject = (from o in _objects where !o.activeInHierarchy select o).FirstOrDefault();
		if (gObject == null)
		{
			gObject = Instantiate(_pooledObject, gameObject.transform);
			_objects.Add(gObject); 
		}

		return gObject;
	}
}
