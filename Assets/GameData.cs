using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

[Serializable]
public class GameData : ISerializable<GameData>
{
	public NumericDataType[] NineNumberDatas;
	public NumericDataType[] IncreaseDecreaseDatas;

	private string _dataPath;

	public void SetDataPath(string dataPath)
	{
		_dataPath = dataPath;
	}

	public GameData Deserialize()
	{
		if (File.Exists(_dataPath))
		{
			string dataAsJson = File.ReadAllText(_dataPath);
			GameData data = JsonUtility.FromJson<GameData>(dataAsJson);
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

		using (StreamWriter streamWriter = new StreamWriter(_dataPath, false))
		{
			streamWriter.Write(json);
			streamWriter.Close();
		}
	}
}
