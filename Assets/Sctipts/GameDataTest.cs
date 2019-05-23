using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataTest : MonoBehaviour
{
	public GameData gameData;

	private string dataPath;

	private void Start()
	{
		string fileName = "gameData.txt";
		dataPath = $"{Application.persistentDataPath}/{fileName}";
		Debug.Log(dataPath);

		int testCount = 2;
		gameData.NineNumberDatas = new NumericDataType[testCount];
		gameData.IncreaseDecreaseDatas = new NumericDataType[testCount];
		for (int i = 0; i < testCount; i++)
		{
			gameData.NineNumberDatas[i] = new NumericDataType(9);
			gameData.IncreaseDecreaseDatas[i] = new NumericDataType(2);
		}

		//gameData.SetDataPath(dataPath);
		//gameData.Serialize();

		gameData.SetDataPath(dataPath);
		GameData data = gameData.Deserialize();

		gameData.NineNumberDatas = data.NineNumberDatas;
		gameData.IncreaseDecreaseDatas = data.IncreaseDecreaseDatas;

		NumericDataType numericDataType = gameData.NineNumberDatas[1];
		QuestionGame questionGame = new QuestionGame(numericDataType, 0);

		string value, question, rightAnswer;
		string[] answers;

		questionGame.CreateQuestion(out value, out question, out answers, out rightAnswer, 4);

		Debug.Log($"value: {value}, question: {question}, right: {rightAnswer}, all answers: {answers[0]} and {answers[1]} ");
		Debug.Log($"and {answers[2]} and {answers[3]} ");
	}
}
