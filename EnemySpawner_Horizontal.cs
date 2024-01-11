using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Horizontal : MonoBehaviour
{
    const float MinY = -10.0f;
    const float MaxY = 10.0f;
    const float a = 0.5f;
    const float b = -0.5f;
    const float c = 10.0f;
    const float d = -10.0f;

    public GameObject enemyPrefab;
    public float interval = 0.5f;

    int spawnCounter = 0;

    private void Awake()
    {
        float rand = Random.Range(-7.0f, 7.0f);  // �������� -7 ~ 7
    }

    private void Start()
    {
        spawnCounter = 0;

        StartCoroutine(SpawnCoroutine());   //�ڷ�ƾ �����ϱ�
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);  //interval ��ŭ ��ٸ� ��
            Spawn();                                    // Spawn ����
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity); // ����
        obj.transform.SetParent(transform); // �θ� ����
        obj.name = $"Enemy_{spawnCounter}"; // ���� ������Ʈ �̸� �ٲٱ�
        spawnCounter++;

    }

    Vector3 GetSpawnPosition()
    {
        Vector3 pos = transform.position;
        pos.x += Random.Range(MinY, MaxY);  // ���� ��ġ���� ���̸� (-4 ~ +4) ����

        return pos;
    }

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
