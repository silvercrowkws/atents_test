using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Horizontal : MonoBehaviour
{
    const float a = 0.5f;
    const float b = -0.5f;
    const float c = 10.0f;
    const float d = -10.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        /*Vector3 p1 = transform.position + (Vector3.right * a) + (Vector3.up * c);
        Vector3 p2 = transform.position + (Vector3.right * a) + Vector3.up * d;
        Vector3 p3 = transform.position + (Vector3.right * b) + Vector3.up * c;
        Vector3 p4 = transform.position + (Vector3.right * b) + Vector3.up * d;*/

        Vector3 p1 = transform.position + (Vector3.right * c);
        Vector3 p2 = transform.position + (Vector3.right * d);
        Vector3 p3 = transform.position + (Vector3.right * c) + (Vector3.up * a);
        Vector3 p4 = transform.position + (Vector3.right * d) + (Vector3.up * a);

       





        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p3, p4);
        Gizmos.DrawLine(p1, p3);
        Gizmos.DrawLine(p2, p4);

       
    }
}
