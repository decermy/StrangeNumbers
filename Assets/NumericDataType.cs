using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

[Serializable]
public class NumericDataType
{
	public int value;

	[Serializable]
	public class Element
	{
		public string equality;
	}

	public Element[] elements;

	public NumericDataType(int elementSize)
	{
		elements = new Element[elementSize];
		for (int i = 0; i < elementSize; i++)
		{
			elements[i] = new Element();
		}
	}
}
