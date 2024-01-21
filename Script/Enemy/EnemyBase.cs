using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : RecycleObject
{
    [Header("�� �⺻ ������")]

    //����
    public int score = 10;

    //������ �� �÷��̾�
    Player player;

    //���� ���� �� ����� ��������Ʈ
    Action onDie;

    protected override void OnEnable()
    {
        base.OnEnable();
        OnInitialize();     // �� �ʱ�ȭ �۾�
    }

    protected override void OnDisable()
    {
        if (player != null)
        {
            onDie -= PlayerAddScore;    // ���������� ����
            onDie = null;               // Ȯ���ϰ� �����Ѵٰ� ǥ��
            player = null;
        }

        base.OnDisable();
    }

    protected virtual void OnInitialize()
    {
        if (player == null)
        {
            player = GameManager.Instance.Player;   // �÷��̾� ã��
        }

        if (player != null)
        {
            onDie += PlayerAddScore;                // �÷��̾� ���� ���� �Լ� ���
        }
    }

    protected virtual void OnDie()
    {
        onDie?.Invoke();
        gameObject.SetActive(false);    // �ڱ� �ڽ� ��Ȱ��ȭ
    }

    //�÷��̾� ���� �߰��� �Լ�(��������Ʈ ��Ͽ�)
    void PlayerAddScore()
    {
        player.AddScore(score);
    }

}
