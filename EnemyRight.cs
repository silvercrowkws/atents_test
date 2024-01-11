using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRight : RecycleObject
{
    public float moveSpeed = 3f; // ��(Enemy)�� �̵� �ӵ�
    private Vector3 moveDirection; // ��(Enemy)�� �̵� ����

    private void Start()
    {
        SetRandomDirection(); // ������ �� ������ ���� ����
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); // ���� �������� �̵�
    }

    private void SetRandomDirection()
    {
        // ������ ���� ����
        float randomAngle = Random.Range(90f, -90f);
        moveDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right;
    }
}
