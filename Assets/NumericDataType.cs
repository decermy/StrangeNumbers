using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

[Serializable]
public class NumericDataType
{
	[Serializable]
	public class Element
	{
		public int value;
		public string equality;

		public bool IsEmpty()
		{
			if (value == 0 || string.IsNullOrEmpty(equality))
			{
				return true;
			}

			return false;
		}
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
