using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionGameHolder : MonoBehaviour
{
	public TextSymbol textSymbolPrefab;
	public TextSymbol questSymbolPrefab;

	public Transform valueTextParent;
	public Transform questionTextParent;

	public Text r_answer, l_answer;

	public Action<string> onAnswerClick = delegate { };

	public void SetValue(string value)
	{
		DetroyChilds(valueTextParent);
		StringRowToTransformArrayForParent(value + "=", valueTextParent, textSymbolPrefab);
	}

	public void SetQuestion(string question)
	{
		DetroyChilds(questionTextParent);
		StringRowToTransformArrayForParent(question, questionTextParent, textSymbolPrefab, questSymbolPrefab);
	}

	public void SetAnswers(string[] answers)
	{
		l_answer.text = answers[0];
		r_answer.text = answers[1];
	}

	public void SetClickAction(Action<string> answerClickAction)
	{
		onAnswerClick = answerClickAction;
	}

	public void OnLeftAnswerClick()
	{
		onAnswerClick.Invoke(l_answer.text);
	}

	public void OnRightAnswerClick()
	{
		onAnswerClick.Invoke(r_answer.text);
	}

	public void StringRowToTransformArrayForParent(string someText, Transform parent, TextSymbol textSymbolPrefab, TextSymbol questSymbolPrefab = null)
	{
		for (int i = 0; i < someText.Length; i++)
		{
			char symbol = someText[i];

			TextSymbol textSymbol;

			if (questSymbolPrefab != null && symbol.Equals('?'))
			{
				textSymbol = Instantiate(questSymbolPrefab);
			}
			else
			{
				textSymbol = Instantiate(textSymbolPrefab);
			}

			textSymbol.SetSymbol(someText[i]);
			textSymbol.transform.SetParent(parent);
		}
	}

	public void DetroyChilds(Transform parent)
	{
		int childCount = parent.childCount;
		for (int i = childCount - 1; i >= 0; i--)
		{
			Destroy(parent.GetChild(i).gameObject);
		}
	}
}
