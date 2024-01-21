using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public bool CanMove { get; set; } = true;

    //플레이어의 점수
    int score = 0;

    private Transform playerChild; // 플레이어의 자식 객체

    private void Start()
    {
        // Player의 0번째 자식 찾기
        playerChild = transform.GetChild(0);
        Time.timeScale = 1.0f;
    }

    private void FixedUpdate()
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

    void Update()
    {
        /*if (CanMove)
        {
            // 키 입력 받기
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // 이동 방향 계산
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            movement.Normalize(); // 대각선 이동 시 이동 속도를 일정하게 유지

            // 플레이어 이동
            transform.Translate(movement * speed * Time.deltaTime);
        }*/
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 객체가 Enemy인지 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Player 파괴
            Destroy(gameObject);
            Time.timeScale = 0.0f;
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            StartCoroutine(ActivateChildFor3Seconds());
        }

    }

    IEnumerator ActivateChildFor3Seconds()
    {
        // Player의 0번째 자식을 활성화
        playerChild.gameObject.SetActive(true);

        // 3초 대기
        yield return new WaitForSeconds(3.0f);

        // 3초 후에 자식 비활성화
        playerChild.gameObject.SetActive(false);
    }

    //점수 확인 및 설정용 프로퍼티
    public int Score
    {
        get => score;   // 읽기는 public
        private set     // 쓰기는 private
        {
            if (score != value)
            {
                score = Math.Min(value, 99999);  // 최대 점수 99999
                onScoreChange?.Invoke(score);   // 이 델리게이트에 함수를 등록한 모든 대상에게 변경된 점수를 알림
            }
        }
    }

    //이 스크립트가 포함된 게임 오브젝트가 생성 완료되면 호출된다.
    public Action<int> onScoreChange;

    // 점수를 추가해주는 변수
    public void AddScore(int getScore)
    {
        Score += getScore;
    }
}
