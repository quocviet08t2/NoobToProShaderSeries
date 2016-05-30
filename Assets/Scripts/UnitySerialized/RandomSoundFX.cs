using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnitySerialized
{
	public enum AudioSourceType
	{
		AudioSourceEffect,
		AudioSourceEnvironment,
		AudioSource3D
	}

	[System.Serializable]
	public class RandomSoundFX
	{
		public AudioSourceType Type;
		public List<AudioClip> ClipColletion;
	}
}
