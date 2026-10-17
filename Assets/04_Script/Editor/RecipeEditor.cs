using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Recipe))]
[CanEditMultipleObjects]
public class RecipeEditor : Editor
{
    SerializedProperty typeSP;
    SerializedProperty inputRessourceSP;
    SerializedProperty outputRessourceSP;
    SerializedProperty productionTimeSP;

    void OnEnable()
    {
        typeSP = serializedObject.FindProperty(nameof(Recipe.type));
        inputRessourceSP = serializedObject.FindProperty(nameof(Recipe.inputRessources));
        outputRessourceSP = serializedObject.FindProperty(nameof(Recipe.outputRessource));
        productionTimeSP = serializedObject.FindProperty(nameof(Recipe.productionTime));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //using (new EditorGUI.DisabledScope(true)) EditorGUILayout.PropertyField(serializedObject.FindProperty("m_script"));

        EditorGUILayout.PropertyField(typeSP);
        EditorGUILayout.Space();

        if (!typeSP.hasMultipleDifferentValues) 
        {
            switch ((Recipe.RecipeType)typeSP.enumValueIndex)
            {
                case Recipe.RecipeType.Fusion:
                    EditorGUILayout.PropertyField(inputRessourceSP, true);
                    EditorGUILayout.PropertyField(outputRessourceSP, true);
                    break;
            }
        }

        EditorGUILayout.PropertyField(productionTimeSP);

        serializedObject.ApplyModifiedProperties();

        DrawWarnings();
    }

    void DrawWarnings()
    {
        bool multiple = targets.Length > 1;

        foreach (Object t in targets)
        {
            Recipe recipe = (Recipe)t;
            if (recipe == null) continue;
            
            foreach (string warning in recipe.warningDetector())
            {
                string message = multiple? $"{recipe.name} : {warning}" : warning;
                EditorGUILayout.HelpBox(message, MessageType.Warning);
            }
        }
    }
}
