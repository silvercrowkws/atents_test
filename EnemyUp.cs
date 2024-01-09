using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUp : MonoBehaviour
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
        float randomAngle = Random.Range(0f, -180f);
        moveDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right;
    }
}
