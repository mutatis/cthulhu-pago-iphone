using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(RigidBody2DUnidirectional))]
public class RigidBody2DUnidirectionInspector : Editor
{
    public override void OnInspectorGUI()
    {
        //Axis axis = Axis.x;
        RigidBody2DUnidirectional myTarget = (RigidBody2DUnidirectional)target;
        myTarget.autoMove = EditorGUILayout.Toggle("Automatic Move",  myTarget.autoMove);
        myTarget.axisToMove = (Axis)EditorGUILayout.EnumPopup("Axis To Move", myTarget.axisToMove);
        /*if (!myTarget.autoMove)
            myTarget.analogicInput = EditorGUILayout.Toggle("analogicInput",  myTarget.analogicInput);

        if (myTarget.analogicInput)
            myTarget.moveForce = EditorGUILayout.FloatField("Force",myTarget.moveForce);*/

        myTarget.maxSpeed = EditorGUILayout.FloatField("Max Speed",myTarget.maxSpeed);

        if (!myTarget.autoMove)
            myTarget.hasLimit = EditorGUILayout.Toggle("Limit", myTarget.hasLimit);

        if (myTarget.hasLimit)
        {
            myTarget.upperLimit = EditorGUILayout.FloatField("Upper Limit",myTarget.upperLimit);
            myTarget.bottomLimit = EditorGUILayout.FloatField("Lower Limit",myTarget.bottomLimit);
        }

        if (GUI.changed)
            EditorUtility.SetDirty(target);

    }
}
