using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public bool CanMove { get; set; } = true;

    void Update()
    {
        if (CanMove)
        {
            // 키 입력 받기
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // 이동 방향 계산
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            movement.Normalize(); // 대각선 이동 시 이동 속도를 일정하게 유지

            // 플레이어 이동
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 객체가 Enemy인지 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Player 파괴
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Non_Player"))
        {
            // Player의 이동을 멈춤
            CanMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 충돌이 끝날 때 Player의 이동을 다시 허용
        CanMove = true;
    }
}
