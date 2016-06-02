using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace UnitySerialized
{
	public enum SoundId
	{
		Effect1,
		Effect3
	}

	public class RandomSoundFxTester : MonoBehaviour
	{
		public RandomSoundFX MyData;
		public RandomSoundFX MyData1;

		[HideInInspector]
		public RandomSoundFX[] DataCollection = new RandomSoundFX[Enum.GetNames(typeof(SoundId)).Length];

		public string GetSoundIdNameById(int id)
		{
			return ((SoundId)id).ToString();
		}
	}
}
