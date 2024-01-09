using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUp : MonoBehaviour
{
    public float moveSpeed = 3f; // 적(Enemy)의 이동 속도
    private Vector3 moveDirection; // 적(Enemy)의 이동 방향

    private void Start()
    {
        SetRandomDirection(); // 시작할 때 무작위 방향 설정
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); // 현재 방향으로 이동
    }

    private void SetRandomDirection()
    {
        // 무작위 방향 설정
        float randomAngle = Random.Range(0f, -180f);
        moveDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right;
    }
}
