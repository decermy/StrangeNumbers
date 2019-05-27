using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestionGameController : MonoBehaviour
{
	public QuestionGameHolder questionGameHolder;

	private QuestionGame.QuestionData questionData;

	public void SetQuest(NumericDataType numericData, int questionVariant)
	{
		QuestionGame questionGame = new QuestionGame(numericData, questionVariant);

		questionData = questionGame.CreateQuestion();

		questionGameHolder.SetValue(questionData.value);
		questionGameHolder.SetQuestion(questionData.question);
		questionGameHolder.SetAnswers(questionData.answers);
		questionGameHolder.SetClickAction(OnCalculate);
	}

	private void OnCalculate(string answer)
	{
		if (answer.Equals(questionData.rightAnswer))
		{
			Win();
		}
		else
		{
			Defeat();
		}
	}

	private void Win()
	{

	}

	private void Defeat()
	{

	}
}
