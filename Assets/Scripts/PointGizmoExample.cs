using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGizmoExample : MonoBehaviour {
    public Color gizmoColor = Color.yellow;
    public float gizmoSize = 0.1f;

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, gizmoSize);
    }
}
