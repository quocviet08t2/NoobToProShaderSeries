using UnityEngine;
using UnityEditor;

namespace UnitySerialized
{
    [CustomPropertyDrawer(typeof(ColorPoint))]
    public class ColorPointDrawer : PropertyDrawer
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

            if (contentPos.height > 16f)
            {
                position.height = 16f;

                // Change indent level and indented this
                EditorGUI.indentLevel += 1;
                contentPos = EditorGUI.IndentedRect(position);

                contentPos.y += 18f;
            }

            contentPos.width *= 0.75f;
            EditorGUI.indentLevel = 0;
            EditorGUI.PropertyField(contentPos, property.FindPropertyRelative("position"), GUIContent.none);
            contentPos.x += contentPos.width;
            contentPos.width /= 3f;
            EditorGUIUtility.labelWidth = 14f;
            EditorGUI.PropertyField(contentPos, property.FindPropertyRelative("color"), new GUIContent("C"));
            EditorGUI.EndProperty();
            EditorGUI.indentLevel = oldIndentLevel;
        }
    }
}