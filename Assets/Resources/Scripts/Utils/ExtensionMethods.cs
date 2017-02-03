using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class ExtensionMethods {

	public static T RandomElement<T>(this List<T> list){
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

}
