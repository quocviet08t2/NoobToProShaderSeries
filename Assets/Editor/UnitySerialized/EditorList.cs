using UnityEditor;
using UnityEngine;
using System;

namespace UnitySerialized
{
    [Flags]
    public enum EditorListOption
    {
        None = 0,
        ListSize = 1,
        ListLabel = 2,
        ElementLabels = 4,
        Default = ListSize | ElementLabels,
        NoElementLabels = ListSize | ListLabel
    }

    public static class EditorList
    {
        public static void Show(SerializedProperty list, EditorListOption option = EditorListOption.Default)
        {
            bool showListLabel = (option & EditorListOption.ListLabel) != 0;
            bool showListSize = (option & EditorListOption.ListSize) != 0;

            if (showListLabel)
            {
                EditorGUILayout.PropertyField(list);
                EditorGUI.indentLevel += 1;
            }
            if (!showListLabel || list.isExpanded)
            {
                if (showListSize)
                {
                    EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
                }
                ShowElements(list, option);
            }
            if (showListLabel)
            {
                EditorGUI.indentLevel -= 1;
            }
        }

        private static void ShowElements (SerializedProperty list, EditorListOption options)
        {
            bool showElementLabels = (options & EditorListOption.ElementLabels) != 0;

            for (int i = 0; i < list.arraySize; i++)
            {
                if (showElementLabels)
                {
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
                }
                else
                {
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);
                }
            }
        }
    }
}