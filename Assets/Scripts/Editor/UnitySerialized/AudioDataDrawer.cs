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
            return label != GUIContent.none && Screen.width < 333 ? (16f + 18f) : 16f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            int oldIndentLevel = EditorGUI.indentLevel;
            label = EditorGUI.BeginProperty(position, label, property);
            Rect contentPos = EditorGUI.PrefixLabel(position, label);

            SerializedProperty list = property.FindPropertyRelative("Value");
            //EditorGUI.PropertyField(contentPos, list.FindPropertyRelative("Array.size"));
            //EditorGUI.indentLevel += 1;
            EditorGUI.PropertyField(contentPos, list, true);

            //contentPos.y += 20;
            //for (int i = 0; i < list.arraySize; i++)
            //{
            //    EditorGUI.PropertyField(contentPos, list.GetArrayElementAtIndex(i));
            //}
            //EditorGUI.indentLevel -= 1;

            EditorGUI.EndProperty();
            EditorGUI.indentLevel = oldIndentLevel;
        }
    }
}