using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreTime;

    // ��ǥ�� �ϴ� ���� ����
    int goalScore = 0;

    // ���� �������� ����
    float currentScore = 0.0f;

    // �ʴ� �ö󰡴� �ӵ�
    public float scoreUpSpeed = 1.0f;

    private void Awake()
    {
        scoreTime = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        // Player�� ã�Ƽ� �̺�Ʈ ���
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onScoreChange += RefreshScore;

        goalScore = 111110;
        currentScore = 0.0f;
        scoreTime.text = "Time : 00.00";
    }

    private void Update()
    {
        if (currentScore < goalScore)    // ������ �ö󰡴� ����
        {
            // �ʴ� �ö󰡴� �ӵ��� ����
            currentScore += Time.deltaTime * scoreUpSpeed;
            currentScore = Mathf.Min(currentScore, goalScore);

            // �ð� ���� ����
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
