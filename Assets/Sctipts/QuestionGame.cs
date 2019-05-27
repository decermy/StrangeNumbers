using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionGame
{
	private NumericDataType _numericData;
	private int _questionVariant;

	public class OperationPoint
	{
		public int position;
		public string operation;

		public OperationPoint(int pos, string oper)
		{
			position = pos;
			operation = oper;
		}
	}

	public class QuestionData
	{
		public string value, question, rightAnswer;
		public string[] answers;
	}

	public QuestionGame(NumericDataType numericData, int questionVariant)
	{
		_numericData = numericData;
		_questionVariant = questionVariant;
	}

	public QuestionData CreateQuestion()
	{
		QuestionData questionData = new QuestionData();

		questionData.value = _numericData.value.ToString();

		string equality = _numericData.elements[_questionVariant].equality;
		List<OperationPoint> operationPoints = new List<OperationPoint>();

		OperationPoint lostOperation = FindOperationForLost(equality, operationPoints);

		questionData.question = string.Copy(equality);
		questionData.question = questionData.question.Remove(lostOperation.position, 1);
		questionData.question = questionData.question.Insert(lostOperation.position, " ? ");

		questionData.answers = CreateAnswers(2, lostOperation);

		questionData.rightAnswer = lostOperation.operation;

		return questionData;
	}

	private void CollectTo(List<OperationPoint> operationPoints, IEnumerable<int> adding, string operation)
	{
		for (int i = 0; i < adding.Count(); i++)
		{
			OperationPoint operationPoint = new OperationPoint(adding.ElementAt(i), operation);
			operationPoints.Add(operationPoint);

			//Debug.Log($"operation : {operationPoint.position} '{operationPoint.operation}'");
		}
	}

	private OperationPoint FindOperationForLost(string equality, List<OperationPoint> operationPoints)
	{
		IEnumerable<int> additionResult = equality.AllIndexesOf("+");
		IEnumerable<int> subtractionResult = equality.AllIndexesOf("-");
		IEnumerable<int> multiplicationResult = equality.AllIndexesOf("×");
		IEnumerable<int> divisionResult = equality.AllIndexesOf("/");

		int maxLenght = Mathf.Max(additionResult.Count(), subtractionResult.Count(), multiplicationResult.Count(), divisionResult.Count());

		CollectTo(operationPoints, additionResult, "+");
		CollectTo(operationPoints, subtractionResult, "-");
		CollectTo(operationPoints, multiplicationResult, "×");
		CollectTo(operationPoints, divisionResult, "/");

		return operationPoints[Random.Range(0, operationPoints.Count)];
	}

	private string[] CreateAnswers(int answersCount, OperationPoint lostOperation)
	{
		if (answersCount < 2 || answersCount > 4)
		{
			Debug.LogError("wrong answers count");
		}

		List<string> answerList = new List<string>();
		answerList.Add(lostOperation.operation);

		List<string> allOperations = new string[] { "+", "-", "×", "/" }.ToList();
		allOperations.Remove(lostOperation.operation);
		System.Random rnd = new System.Random();
		string[] allOperationsRandom = allOperations.OrderBy(x => rnd.Next()).ToArray();

		for (int i = 0; i < answersCount - 1; i++)
		{
			answerList.Add(allOperationsRandom[i]);
		}

		return answerList.OrderBy(x => rnd.Next()).ToArray();
		//return answerList.ToArray();
	}
}