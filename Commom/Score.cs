using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreTime;

    // 목표로 하는 최종 점수
    int goalScore = 0;

    // 현재 보여지는 점수
    float currentScore = 0.0f;

    // 초당 올라가는 속도
    public float scoreUpSpeed = 1.0f;

    private void Awake()
    {
        scoreTime = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        // Player를 찾아서 이벤트 등록
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onScoreChange += RefreshScore;

        goalScore = 111110;
        currentScore = 0.0f;
        scoreTime.text = "Time : 00.00";
    }

    private void Update()
    {
        if (currentScore < goalScore)    // 점수가 올라가는 도중
        {
            // 초당 올라가는 속도로 변경
            currentScore += Time.deltaTime * scoreUpSpeed;
            currentScore = Mathf.Min(currentScore, goalScore);

            // 시간 포맷 변경
            int minutes = (int)(currentScore / 60);
            int seconds = (int)(currentScore % 60);

            scoreTime.text = $"Time : {minutes:00}:{seconds:00}";
        }
    }

    public void RefreshScore(int newScore)
    {
        goalScore = newScore;
    }
}
