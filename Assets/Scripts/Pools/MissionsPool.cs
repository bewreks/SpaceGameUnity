using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsPool : Pool {

	public static Pool current;

	private void Awake()
	{
		current = this;
	}

}
