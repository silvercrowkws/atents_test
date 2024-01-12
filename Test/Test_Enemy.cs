using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Enemy : MonoBehaviour
{
    private void Update()
    {
        MoveTowardsGoal();
    }

    private void MoveTowardsGoal()
    {
        // Test_Goal 스크립트를 찾아옵니다.
        Test_Goal testGoal = FindObjectOfType<Test_Goal>();

        if (testGoal != null)
        {
            // Test_Goal의 범위를 가져옵니다.
            float goalXMin = testGoal.GetXMin();
            float goalXMax = testGoal.GetXMax();
            float goalYMin = testGoal.GetYMin();
            float goalYMax = testGoal.GetYMax();

            // 현재 위치를 가져옵니다.
            Vector3 currentPosition = transform.position;

            // 적이 Test_Goal의 범위를 벗어나지 않도록 이동합니다.
            float newX = Mathf.Clamp(currentPosition.x, goalXMin, goalXMax);
            float newY = Mathf.Clamp(currentPosition.y, goalYMin, goalYMax);

            // 새로운 위치를 설정합니다.
            transform.position = new Vector3(newX, newY, currentPosition.z);
        }
    }
}

