using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnitySerialized
{
	public enum AudioType
	{
		AudioSourceEffect,
		AudioSourceEnvironment,
		AudioSource3D
	}

	[System.Serializable]
	public class AudioData
	{
		public AudioType Type;
		public List<AudioClip> ClipColletion;
	}
}
