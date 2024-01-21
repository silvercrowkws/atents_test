using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : RecycleObject
{
    // 이동 속도
    public float moveSpeed = 2.0f;

    // 벽에 부딪칠 때 방향 전환 횟수
    public int dirChangeCountMax = 5;

    // 현재 이동 방향
    Vector3 direction;

    // 벽에 부딪치면 방향 전환 횟수 감소
    int DirChangeCount;
       

    public void Initialize()
    {
        // 랜덤한 각도를 105에서 165도 사이로 설정
        float randomAngle = Random.Range(105.0f, 165.0f);

        direction = Quaternion.Euler(0, 0, randomAngle) * Vector3.up;

        DirChangeCount = dirChangeCountMax; // 방향 전환 횟수 초기화

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Initialize();

    }

    protected override void OnDisable()
    {
        base.OnDisable();

    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * direction); // 항상 direction 방향으로 이동
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border")) // 벽에 부딪치면
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal); // 이동 방향 반사
            DirChangeCount--; // 방향 전환 횟수 감소

            if (DirChangeCount <= 0)
            {
                // 방향 전환 횟수가 0 이하면 오브젝트 비활성화
                gameObject.SetActive(false);
            }
        }


        if (collision.gameObject.CompareTag("Player"))
        {
           /* // Player를 밀어내는 힘을 제거하고 싶다면 아래의 코드를 사용
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // 플레이어를 밀어내는 힘을 0으로 설정
                playerRb.velocity = Vector2.zero;
            }*/

            gameObject.SetActive(false);

            
        }
    }

    



}
