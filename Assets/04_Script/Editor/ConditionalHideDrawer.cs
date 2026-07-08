using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
public class ConditionalHidePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute CHA = (ConditionalHideAttribute)attribute;
        SerializedProperty enumProperty = property.serializedObject.FindProperty(CHA.propertyName);

        if (enumProperty == null || enumProperty.enumValueIndex != CHA.enumValue)
        {
            return; 
        }

        EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute CHA = (ConditionalHideAttribute)attribute;
        SerializedProperty enumProperty = property.serializedObject.FindProperty(CHA.propertyName);

        if (enumProperty == null || enumProperty.enumValueIndex != CHA.enumValue)
        {
            return 0f;
        }

        return EditorGUI.GetPropertyHeight(property, label);
    }
}