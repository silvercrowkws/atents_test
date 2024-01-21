using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //기즈모 그릴 크기
    public float halfWidth = 2.0f;  // 반대편으로의 거리의 반

    //아이템 생성 간격
    private float spawnInterval = 5.0f;
    private float timer = 0.0f; // 경과 시간을 측정할 타이머

    Vector3[] spawnPositions;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 center = new Vector3(8.5f, 4.5f, 0);

        // 좌상에서 우하로 가는 대각선 그리기
        Vector3 topLeft = center + new Vector3(-halfWidth, halfWidth, 0);
        Vector3 bottomRight = center + new Vector3(halfWidth, -halfWidth, 0);

        Gizmos.DrawLine(topLeft, bottomRight);
    }

    private void Update()
    {
        // 타이머를 업데이트하고 일정 시간이 경과하면 SpawnEnemy 메서드를 호출합니다.
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0.0f; // 타이머를 리셋합니다.
        }

        spawnPositions = new Vector3[]
        {
            new Vector3(8.5f , 4.5f, 0)
        };
    }

    Vector3 GetSpawnPosition()
    {
        // 배열에서 랜덤하게 하나를 선택하여 반환합니다.
        return spawnPositions[Random.Range(0, spawnPositions.Length)];
    }

    void SpawnItem()
    {
        Factory.Instance.GetShield(GetSpawnPosition());
    }

}
