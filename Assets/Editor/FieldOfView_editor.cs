using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfView_editor : Editor
{
    void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;

        Handles.color = Color.white;

        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.eyeRadius);

        Vector3 viewAngleA = fov.findTargetAngle(-fov.eyeAngle / 2, false);
        Vector3 viewAngleB = fov.findTargetAngle(fov.eyeAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.eyeRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.eyeRadius);

        Handles.color = Color.red;
        if (fov.target)
        {
            Handles.DrawLine(fov.transform.position, fov.target.position);
        }
    }
}
