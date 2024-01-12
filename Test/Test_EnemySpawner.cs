using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_EnemySpawner : MonoBehaviour
{
    // x �� ����
    float xMin = -10f;
    float xMax = 10f;

    // y �� ����
    float yMin = -6f;
    float yMax = 6f;

    public GameObject Test_EnemyPrefab;

    private float spawnInterval = 1.0f; // ���� ����
    private float timer = 0.0f; // ��� �ð��� ������ Ÿ�̸�

    private void OnDrawGizmos()
    {
        DrawGizmo();
    }

    private void DrawGizmo()
    {
        Gizmos.color = Color.green;

        // ���� ����� Gizmo�� �׸��ϴ�.
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
        // Ÿ�̸Ӹ� ������Ʈ�ϰ� ���� �ð��� ����ϸ� SpawnEnemy �޼��带 ȣ���մϴ�.
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0.0f; // Ÿ�̸Ӹ� �����մϴ�.
        }
    }

    void SpawnEnemy()
    {
        // ���� ��ġ�� �����մϴ�. topLeft�� topRight ���̿��� ������ ��ġ�Դϴ�.
        Vector3 topLeft = new Vector3(xMin, yMax, 0);
        Vector3 topRight = new Vector3(xMax, yMax, 0);
        Vector3 bottomLeft = new Vector3(xMin, yMin, 0);
        Vector3 bottomRight = new Vector3(xMax, yMin, 0);

        float spawnX = Random.Range(topLeft.x, topRight.x);
        float spawnY = Random.Range(topLeft.y, topRight.y); // y���� ������ �� ���� �� �Ʒ� ���̿��� �����ϰ� �����մϴ�.
        float spawnZ = Random.Range(bottomLeft.x, bottomRight.x);
        float spawnW = Random.Range(bottomLeft.y, bottomRight.y);
        float spawnA = Random.Range(topLeft.x, bottomLeft.x);
        float spawnB = Random.Range(topLeft.y, bottomLeft.y);
        float spawnC = Random.Range(topRight.x, bottomRight.x);
        float spawnD = Random.Range(topRight.y, bottomRight.y);

        // Test_Enemy �������� ���� ��ġ�� �ν��Ͻ�ȭ�մϴ�.
        Instantiate(Test_EnemyPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
        Instantiate(Test_EnemyPrefab, new Vector3(spawnZ, spawnW, 0), Quaternion.identity);
        Instantiate(Test_EnemyPrefab, new Vector3(spawnA, spawnB, 0), Quaternion.identity);
        Instantiate(Test_EnemyPrefab, new Vector3(spawnC, spawnD, 0), Quaternion.identity);
        
    }

}
