using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveRandomDirection();
    }

    void MoveRandomDirection()
    {
        // x�� y�� ������ ��ǥ�� �����մϴ�.
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-3f, 3f);

        // ���� ��ġ�� ������ ������ ��ǥ ������ ������ ����մϴ�.
        Vector2 moveDirection = new Vector2(randomX - transform.position.x, randomY - transform.position.y).normalized;

        // ������ �������� �̵��մϴ�.
        rb.velocity = moveDirection * moveSpeed;
    }
}
