using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Movement)), CanEditMultipleObjects]
public class MovementInspector : Editor
{
    public SerializedProperty
        canControl,
        movement,
        movementType;

    ScriptableObject scriptableObject;

    void OnEnable()
    {
        canControl = serializedObject.FindProperty("canControl");
        movement = serializedObject.FindProperty("movement2d");
        movementType = serializedObject.FindProperty("movementType");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(canControl);
        EditorGUILayout.PropertyField(movementType);
        Movement.MovementType mt = (Movement.MovementType)movementType.enumValueIndex;
        switch (mt)
        {
            case Movement.MovementType.Rigidbody2DUnidirectional:
                EditorGUILayout.PropertyField(movement, new GUIContent("Rigidbody2DUnidirectional"), true);
                break;
            case Movement.MovementType.Rigidbody2DBidirectional:
                EditorGUILayout.PropertyField(movement, new GUIContent("Rigidbody2DBidirectional"), true);
                break;
            case Movement.MovementType.Rigidbody2DFourDirectional:
                EditorGUILayout.PropertyField(movement, new GUIContent("Rigidbody2DFourDirectional"), true);
                break;
            case Movement.MovementType.Rigidbody2DEightDirectional:
                EditorGUILayout.PropertyField(movement, new GUIContent("Rigidbody2DEightDirectional"), true);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

}
