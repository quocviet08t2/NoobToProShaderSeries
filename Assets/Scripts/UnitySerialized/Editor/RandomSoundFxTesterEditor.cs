using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

namespace UnitySerialized
{
	[CustomEditor(typeof(RandomSoundFxTester))]
	public class RandomSoundFxTesterEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawDefaultInspector();

			RandomSoundFxTester soundTester = (RandomSoundFxTester)serializedObject.targetObject;

			// Draw random sound fx list
			EditorGUIHelper.PropertyArray(serializedObject.FindProperty("DataCollection"),
				Enum.GetNames(typeof(SoundId)).Length,
				(i) => { return soundTester.GetSoundIdNameById(i); });

			if (GUI.changed)
			{
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}