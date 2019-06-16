using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility {

	public static T[] ShuffleArray<T>(T[] array,int seed)
	{
		System.Random rnd = new System.Random(seed);

		for (int i = 0; i < array.Length; i++)
		{
			int randomIndex = rnd.Next(i,array.Length);
			T templateItem = array[randomIndex];
			array[randomIndex] = array[i];
			array[i] = templateItem;
		}
		return array;
	}
}


