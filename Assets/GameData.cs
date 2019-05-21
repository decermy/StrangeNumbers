using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

[Serializable]
public class GameData : MonoBehaviour, ISerializable
{
	public NumericDataType[] NineNumberDatas;
	public NumericDataType[] IncreaseDecreaseDatas;

	private string dataPath;

	private void Start()
	{
		string fileName = "gameData.txt";
		dataPath = $"{Application.persistentDataPath}/{fileName}";
		Debug.Log(dataPath);

		int testCount = 2;
		NineNumberDatas = new NumericDataType[testCount];
		IncreaseDecreaseDatas = new NumericDataType[testCount];
		for (int i = 0; i < testCount; i++)
		{
			NineNumberDatas[i] = new NumericDataType(9);
			IncreaseDecreaseDatas[i] = new NumericDataType(2);
		}

		Serialize();
	}

	public object Deserialize()
	{
		if (File.Exists(dataPath))
		{
			string dataAsJson = File.ReadAllText(dataPath);
			object data = JsonUtility.FromJson<object>(dataAsJson);
			if (data != null)
			{
				return data;
			}
			else
			{
				Debug.LogError("Data broken");
			}
		}
		else
		{
			Debug.LogError("Cannot load game data!");
		}

		return null;
	}

	public void Serialize()
	{
		string json = JsonUtility.ToJson(this, true);

		using (StreamWriter streamWriter = new StreamWriter(dataPath, false))
		{
			streamWriter.Write(json);
			streamWriter.Close();
		}
	}
}
