using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //����� �׸� ũ��
    public float halfWidth = 2.0f;  // �ݴ��������� �Ÿ��� ��

    //������ ���� ����
    private float spawnInterval = 5.0f;
    private float timer = 0.0f; // ��� �ð��� ������ Ÿ�̸�

    Vector3[] spawnPositions;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 center = new Vector3(8.5f, 4.5f, 0);

        // �»󿡼� ���Ϸ� ���� �밢�� �׸���
        Vector3 topLeft = center + new Vector3(-halfWidth, halfWidth, 0);
        Vector3 bottomRight = center + new Vector3(halfWidth, -halfWidth, 0);

        Gizmos.DrawLine(topLeft, bottomRight);
    }

    private void Update()
    {
        // Ÿ�̸Ӹ� ������Ʈ�ϰ� ���� �ð��� ����ϸ� SpawnEnemy �޼��带 ȣ���մϴ�.
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0.0f; // Ÿ�̸Ӹ� �����մϴ�.
        }

        spawnPositions = new Vector3[]
        {
            new Vector3(8.5f , 4.5f, 0)
        };
    }

    Vector3 GetSpawnPosition()
    {
        // �迭���� �����ϰ� �ϳ��� �����Ͽ� ��ȯ�մϴ�.
        return spawnPositions[Random.Range(0, spawnPositions.Length)];
    }

    void SpawnItem()
    {
        Factory.Instance.GetShield(GetSpawnPosition());
    }

}
