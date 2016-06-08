///////////////////////////////////////////////////////////////////////////////
// Copyright (C) 2015 AsNet Co., Ltd.
// All Rights Reserved. These instructions, statements, computer
// programs, and/or related material (collectively, the "Source")
// contain unpublished information proprietary to AsNet Co., Ltd
// which is protected by US federal copyright law and by
// international treaties. This Source may NOT be disclosed to
// third parties, or be copied or duplicated, in whole or in
// part, without the written consent of AsNet Co., Ltd.
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;
using System;
using UnitySerialized;

public static class EditorGUIHelper
{
	public static string[] orderNameList;

	public static void PropertyArray1(SerializedProperty array, int count, Func<int, string> func)
	{
		EditorGUI.indentLevel = 0;
		EditorGUILayout.PropertyField(array);

		if (array.isExpanded)
		{
			EditorGUI.indentLevel++;

			RandomSoundFxTester soundTester = (RandomSoundFxTester)array.serializedObject.targetObject;
			RandomSoundFX[] DataCollection = soundTester.DataCollection;

			SerializedProperty property0 = array.GetArrayElementAtIndex(0);

			// Transfer value
			if (array.arraySize < count)
			{
				//do
				//{
				//	array.InsertArrayElementAtIndex(array.arraySize);
				//}
				//while (array.arraySize < count);

				for (int i = 0; i < count; i++)
				{
					if (!orderNameList[i].Equals(func(i)))
					{
						array.arraySize++;
						array.MoveArrayElement(i, i + 1);
					}
				}
			}
			else if (array.arraySize > count)
			{
				//do
				//{
				//	array.DeleteArrayElementAtIndex(array.arraySize - 1);
				//}
				//while (array.arraySize > count);
			}

			if (array.arraySize == count)
			{
				orderNameList = new string[count];
				for (int i = 0; i < count; i++)
				{
					orderNameList[i] = string.Copy(func(i));
				}
			}

			for (int i = 0; i < array.arraySize; i++)
			{
				EditorGUILayout.PropertyField(array.GetArrayElementAtIndex(i), new GUIContent(func(i)));
			}

			EditorGUI.indentLevel--;
		}
	}

	public static void PropertyArray(SerializedProperty array, int count, Func<int, string> func)
	{
		EditorGUI.indentLevel = 0;
		EditorGUILayout.PropertyField(array);

		if (array.isExpanded)
		{
			EditorGUI.indentLevel++;

			if (array.arraySize < count)
			{
				do
				{
					array.arraySize++;
					array.InsertArrayElementAtIndex(array.arraySize);
				}
				while (array.arraySize < count);
			}
			else if (array.arraySize > count)
			{
				do
				{
					array.DeleteArrayElementAtIndex(array.arraySize - 1);
				}
				while (array.arraySize > count);
			}

			for (int i = 0; i < array.arraySize; i++)
			{
				EditorGUILayout.PropertyField(array.GetArrayElementAtIndex(i), new GUIContent(func(i)));
			}

			EditorGUI.indentLevel--;
		}
	}
}
