using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Goal : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        // 사각형 모양의 Gizmo를 그립니다.
        float xMin = -5f;
        float xMax = 5f;
        float yMin = -2f;
        float yMax = 2f;

        Vector3 topLeft = new Vector3(xMin, yMax, 0);
        Vector3 topRight = new Vector3(xMax, yMax, 0);
        Vector3 bottomLeft = new Vector3(xMin, yMin, 0);
        Vector3 bottomRight = new Vector3(xMax, yMin, 0);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
        
}
