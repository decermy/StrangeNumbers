﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializable
{
	void Serialize();
	object Deserialize();
}
