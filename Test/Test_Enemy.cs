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
        // Test_Goal ��ũ��Ʈ�� ã�ƿɴϴ�.
        Test_Goal testGoal = FindObjectOfType<Test_Goal>();

        if (testGoal != null)
        {
            // Test_Goal�� ������ �����ɴϴ�.
            float goalXMin = testGoal.GetXMin();
            float goalXMax = testGoal.GetXMax();
            float goalYMin = testGoal.GetYMin();
            float goalYMax = testGoal.GetYMax();

            // ���� ��ġ�� �����ɴϴ�.
            Vector3 currentPosition = transform.position;

            // ���� Test_Goal�� ������ ����� �ʵ��� �̵��մϴ�.
            float newX = Mathf.Clamp(currentPosition.x, goalXMin, goalXMax);
            float newY = Mathf.Clamp(currentPosition.y, goalYMin, goalYMax);

            // ���ο� ��ġ�� �����մϴ�.
            transform.position = new Vector3(newX, newY, currentPosition.z);
        }
    }
}

