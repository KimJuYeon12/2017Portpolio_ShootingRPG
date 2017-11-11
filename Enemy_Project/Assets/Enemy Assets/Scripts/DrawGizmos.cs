using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class DrawGizmos : MonoBehaviour
{
    public Color gizmosColor = new Color(0.5f, 0.9f, 1.0f, 0.5f);

    //[DrawGizmo (GizmoType.NonSelected | GizmoType.Active)]
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }
}