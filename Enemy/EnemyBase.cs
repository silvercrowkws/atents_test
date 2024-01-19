using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : RecycleObject
{
    [Header("적 기본 데이터")]

    //점수
    public int score = 10;

    //점수를 줄 플레이어
    Player player;

    //적이 죽을 때 실행될 델리게이트
    Action onDie;

    protected override void OnEnable()
    {
        base.OnEnable();
        OnInitialize();     // 적 초기화 작업
    }

    protected override void OnDisable()
    {
        if (player != null)
        {
            onDie -= PlayerAddScore;    // 순차적으로 제거
            onDie = null;               // 확실하게 정리한다고 표시
            player = null;
        }

        base.OnDisable();
    }

    protected virtual void OnInitialize()
    {
        if (player == null)
        {
            player = GameManager.Instance.Player;   // 플레이어 찾기
        }

        if (player != null)
        {
            onDie += PlayerAddScore;                // 플레이어 점수 증가 함수 등록
        }
    }

    protected virtual void OnDie()
    {
        onDie?.Invoke();
        gameObject.SetActive(false);    // 자기 자신 비활성화
    }

    //플레이어 점수 추가용 함수(델리게이트 등록용)
    void PlayerAddScore()
    {
        player.AddScore(score);
    }

}
