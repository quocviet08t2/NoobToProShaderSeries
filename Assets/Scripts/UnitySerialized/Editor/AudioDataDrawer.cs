using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;

namespace UnitySerialized
{
    [CustomPropertyDrawer(typeof(AudioData))]
    public class AudioDataDrawer : PropertyDrawer
    {
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			//SerializedProperty list = property.FindPropertyRelative("ClipColletion");
			//int arraySize = list.arraySize;

			//if (list.isExpanded)
			//{
			//	return (18f + (arraySize + 2) * 18f);
			//}
			//else
			//{
			//	return 2 * 18f;
			//}

			return 200f;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
			int oldIndentLevel = EditorGUI.indentLevel;
			label = EditorGUI.BeginProperty(position, label, property);
			Rect contentPos = EditorGUI.PrefixLabel(position, label);

			EditorGUI.indentLevel = 0;

			position.y += 18f;
			EditorGUI.PropertyField(position, property.FindPropertyRelative("Type"), true);

			position.y += 18f;
			EditorGUI.PropertyField(position, property.FindPropertyRelative("ClipColletion"), true);

			EditorGUI.EndProperty();
			EditorGUI.indentLevel = oldIndentLevel;
		}
    }
}
