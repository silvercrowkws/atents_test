using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Vertical : MonoBehaviour
{
    const float MinY = -7.0f;
    const float MaxY = 7.0f;
    const float a = 0.5f;
    const float b = -0.5f;
    const float c = 7.0f;
    const float d = -7.0f;

    public GameObject emenyPrefab;
    public float interval = 0.5f;

    int spawnCounter = 0;

    private void Awake()
    {
        float rand = Random.Range(-7.0f, 7.0f);  // 랜덤으로 -7 ~ 7
    }

    private void Start()
    {
        spawnCounter = 0;

        StartCoroutine(SpawnCoroutine());   //코루틴 실행하기
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);  //interval 만큼 기다린 후
            Spawn();                                    // Spawn 실행
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(emenyPrefab, GetSpawnPosition(), Quaternion.identity); // 생성
        obj.transform.SetParent(transform); // 부모 설정
        obj.name = $"Enemy_{spawnCounter}"; // 게임 오브젝트 이름 바꾸기
        spawnCounter++;

    }

    Vector3 GetSpawnPosition()
    {
        Vector3 pos = transform.position;
        pos.y += Random.Range(MinY, MaxY);  // 현재 위치에서 높이만 (-4 ~ +4) 변경

        return pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 p1 = transform.position + (Vector3.up * c);
        Vector3 p2 = transform.position + (Vector3.up * d);
        Vector3 p3 = transform.position + (Vector3.right * a) + (Vector3.up * c);
        Vector3 p4 = transform.position + (Vector3.right * a) + (Vector3.up * d);



        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p3, p4);
        Gizmos.DrawLine(p1, p3);
        Gizmos.DrawLine(p2, p4);
    }
}
