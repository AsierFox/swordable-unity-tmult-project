using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraFollow cameraFollow = (CameraFollow) target;

        if (GUILayout.Button("Set Min Camera pos"))
        {
            cameraFollow.SetMinCameraPosition();
        }

        if (GUILayout.Button("Set Max Camera pos"))
        {
            cameraFollow.SetMaxCameraPosition();
        }
    }

}
