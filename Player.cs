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

    //�÷��̾��� ����
    int score = 0;

    private void FixedUpdate()
    {
        if (CanMove)
        {
            // Ű �Է� �ޱ�
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // �̵� ���� ���
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            movement.Normalize(); // �밢�� �̵� �� �̵� �ӵ��� �����ϰ� ����

            // �÷��̾� �̵�
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    void Update()
    {
        /*if (CanMove)
        {
            // Ű �Է� �ޱ�
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // �̵� ���� ���
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            movement.Normalize(); // �밢�� �̵� �� �̵� �ӵ��� �����ϰ� ����

            // �÷��̾� �̵�
            transform.Translate(movement * speed * Time.deltaTime);
        }*/
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ��ü�� Enemy���� Ȯ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Player �ı�
            Destroy(gameObject);
        }

    }

    //���� Ȯ�� �� ������ ������Ƽ
    public int Score
    {
        get => score;   // �б�� public
        private set     // ����� private
        {
            if (score != value)
            {
                score = Math.Min(value, 99999);  // �ִ� ���� 99999
                onScoreChange?.Invoke(score);   // �� ��������Ʈ�� �Լ��� ����� ��� ��󿡰� ����� ������ �˸�
            }
        }
    }

    //�� ��ũ��Ʈ�� ���Ե� ���� ������Ʈ�� ���� �Ϸ�Ǹ� ȣ��ȴ�.
    public Action<int> onScoreChange;

    // ������ �߰����ִ� ����
    public void AddScore(int getScore)
    {
        Score += getScore;
    }
}
