using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionGameHolder : MonoBehaviour
{
	public Text valueText;
	public Text equalityText;

	public Text r_answer, l_answer;

	public Action<string> onAnswerClick = delegate { };

	public void SetValue(string value)
	{

	}

	public void SetQuestion(string question)
	{

	}

	public void SetAnswers(string[] answers)
	{

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
}
