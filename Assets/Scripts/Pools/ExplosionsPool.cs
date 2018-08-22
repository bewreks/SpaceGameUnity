using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsPool : Pool
{

	public static Pool current;

	private void Awake()
	{
		current = this;
	}
}
