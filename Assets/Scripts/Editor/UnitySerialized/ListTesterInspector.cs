using UnityEditor;
using UnityEngine;

namespace UnitySerialized
{
    [CustomEditor(typeof(ListTester))]
    public class ListTesterInspector : Editor
    {

        //public override void OnInspectorGUI()
        //{
        //    serializedObject.Update();
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("integers"), true);
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("vectors"), true);
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("colorPoints"), true);
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("objects"), true);
        //    serializedObject.ApplyModifiedProperties();
        //}

        // My inspector gui
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorList.Show(serializedObject.FindProperty("integers"), EditorListOption.NoElementLabels);
            EditorList.Show(serializedObject.FindProperty("vectors"));
			EditorList.Show(serializedObject.FindProperty("colorPoints"), EditorListOption.Buttons);
			EditorList.Show(serializedObject.FindProperty("objects"), EditorListOption.ListLabel | EditorListOption.Buttons);
			serializedObject.ApplyModifiedProperties();
        }
    }
}
