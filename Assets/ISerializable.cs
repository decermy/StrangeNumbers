﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializable<T>
{
	void Serialize();
	T Deserialize();
}
