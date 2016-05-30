using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UnitySerialized
{
	[CustomPropertyDrawer(typeof(RandomSoundFX))]
	public class AudioDataDrawer : PropertyDrawer
	{
		private static GUIContent deleteButtonContent = new GUIContent("-", "delete");
		private static GUIContent addButtonContent = new GUIContent("+", "add element");
		private const float _lineHeight = 16f;
		private const float _lineHeightWithGap = 18f;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty list = property.FindPropertyRelative("ClipColletion");

			if (property.isExpanded)
			{
				return (3 * _lineHeightWithGap + (list.arraySize == 0 ? _lineHeightWithGap : list.arraySize * _lineHeightWithGap));
			}
			else
			{
				return _lineHeightWithGap;
			}
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			int oldIndentLevel = EditorGUI.indentLevel;
			label = EditorGUI.BeginProperty(position, label, property);

			position.Set(position.x, position.y, position.width, _lineHeight);
			property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label, true);
			if (property.isExpanded)
			{
				position.y += _lineHeightWithGap;
				EditorGUI.PropertyField(position, property.FindPropertyRelative("Type"));

				position.y += _lineHeightWithGap;
				EditorGUI.LabelField(position, "AudioClips");

				EditorGUI.indentLevel ++;
				SerializedProperty clipCollection = property.FindPropertyRelative("ClipColletion");
				position.y += _lineHeightWithGap;
				ShowElement(position, clipCollection);

				// Array size must > 0
				if (clipCollection.arraySize == 0)
				{
					clipCollection.arraySize += 1;
				}
			}

			EditorGUI.EndProperty();
			EditorGUI.indentLevel = oldIndentLevel;
		}

		private static void ShowElement(Rect position, SerializedProperty list)
		{
			for (int i = 0; i < list.arraySize; i++)
			{
				EditorGUI.PropertyField(new Rect(position.x, position.y, position.width - 60f, _lineHeight), 
					list.GetArrayElementAtIndex(i), GUIContent.none);
				ShowButtons(position, list, i);
				position.y += _lineHeightWithGap;
			}
		}

		private static void ShowButtons(Rect position, SerializedProperty list, int index)
		{
			position.Set(position.width - 37f, position.y, 25f, _lineHeight);
			if (GUI.Button(position, addButtonContent, EditorStyles.miniButtonLeft))
			{
				list.InsertArrayElementAtIndex(index);
			}

			position.Set(position.x + position.width, position.y, position.width, position.height);
			if (GUI.Button(position, deleteButtonContent, EditorStyles.miniButtonRight))
			{
				int oldSize = list.arraySize;

				if (list.arraySize > 0)
				{
					list.DeleteArrayElementAtIndex(index);
					if (list.arraySize == oldSize)
					{
						list.DeleteArrayElementAtIndex(index);
					}
				}
			}
		}
	}
}
