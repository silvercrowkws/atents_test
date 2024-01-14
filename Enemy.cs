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
        // x와 y의 무작위 좌표를 설정합니다.
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-3f, 3f);

        // 현재 위치와 설정된 무작위 좌표 사이의 방향을 계산합니다.
        Vector2 moveDirection = new Vector2(randomX - transform.position.x, randomY - transform.position.y).normalized;

        // 설정된 방향으로 이동합니다.
        rb.velocity = moveDirection * moveSpeed;
    }
}
