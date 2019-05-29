using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextSymbol : MonoBehaviour
{
	public Text textComponent;

	public void SetSymbol(char symbol)
	{
		textComponent.text = symbol.ToString();
	}
}
