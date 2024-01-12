using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_EnemySpawner : MonoBehaviour
{
    // x 축 범위
    float xMin = -10f;
    float xMax = 10f;

    // y 축 범위
    float yMin = -6f;
    float yMax = 6f;

    public GameObject Test_EnemyPrefab;

    private float spawnInterval = 1.0f; // 생성 간격
    private float timer = 0.0f; // 경과 시간을 측정할 타이머

    private void OnDrawGizmos()
    {
        DrawGizmo();
    }

    private void DrawGizmo()
    {
        Gizmos.color = Color.green;

        // 상자 모양의 Gizmo를 그립니다.
        Vector3 topLeft = new Vector3(xMin, yMax, 0);
        Vector3 topRight = new Vector3(xMax, yMax, 0);
        Vector3 bottomLeft = new Vector3(xMin, yMin, 0);
        Vector3 bottomRight = new Vector3(xMax, yMin, 0);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }

    private void Update()
    {
        // 타이머를 업데이트하고 일정 시간이 경과하면 SpawnEnemy 메서드를 호출합니다.
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0.0f; // 타이머를 리셋합니다.
        }
    }

    void SpawnEnemy()
    {
        // 생성 위치를 정의합니다. topLeft와 topRight 사이에서 랜덤한 위치입니다.
        Vector3 topLeft = new Vector3(xMin, yMax, 0);
        Vector3 topRight = new Vector3(xMax, yMax, 0);
        Vector3 bottomLeft = new Vector3(xMin, yMin, 0);
        Vector3 bottomRight = new Vector3(xMax, yMin, 0);

        float spawnX = Random.Range(topLeft.x, topRight.x);
        float spawnY = Random.Range(topLeft.y, topRight.y); // y값은 상자의 맨 위와 맨 아래 사이에서 랜덤하게 설정합니다.
        float spawnZ = Random.Range(bottomLeft.x, bottomRight.x);
        float spawnW = Random.Range(bottomLeft.y, bottomRight.y);
        float spawnA = Random.Range(topLeft.x, bottomLeft.x);
        float spawnB = Random.Range(topLeft.y, bottomLeft.y);
        float spawnC = Random.Range(topRight.x, bottomRight.x);
        float spawnD = Random.Range(topRight.y, bottomRight.y);

        // Test_Enemy 프리팹을 생성 위치에 인스턴스화합니다.
        Instantiate(Test_EnemyPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
        Instantiate(Test_EnemyPrefab, new Vector3(spawnZ, spawnW, 0), Quaternion.identity);
        Instantiate(Test_EnemyPrefab, new Vector3(spawnA, spawnB, 0), Quaternion.identity);
        Instantiate(Test_EnemyPrefab, new Vector3(spawnC, spawnD, 0), Quaternion.identity);
        
    }

}
