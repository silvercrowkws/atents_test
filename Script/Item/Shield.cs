using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : RecycleObject
{
    // �̵� �ӵ�
    public float moveSpeed = 2.0f;

    // ���� �ε�ĥ �� ���� ��ȯ Ƚ��
    public int dirChangeCountMax = 5;

    // ���� �̵� ����
    Vector3 direction;

    // ���� �ε�ġ�� ���� ��ȯ Ƚ�� ����
    int DirChangeCount;
       

    public void Initialize()
    {
        // ������ ������ 105���� 165�� ���̷� ����
        float randomAngle = Random.Range(105.0f, 165.0f);

        direction = Quaternion.Euler(0, 0, randomAngle) * Vector3.up;

        DirChangeCount = dirChangeCountMax; // ���� ��ȯ Ƚ�� �ʱ�ȭ

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
        transform.Translate(Time.deltaTime * moveSpeed * direction); // �׻� direction �������� �̵�
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border")) // ���� �ε�ġ��
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal); // �̵� ���� �ݻ�
            DirChangeCount--; // ���� ��ȯ Ƚ�� ����

            if (DirChangeCount <= 0)
            {
                // ���� ��ȯ Ƚ���� 0 ���ϸ� ������Ʈ ��Ȱ��ȭ
                gameObject.SetActive(false);
            }
        }


        if (collision.gameObject.CompareTag("Player"))
        {
           /* // Player�� �о�� ���� �����ϰ� �ʹٸ� �Ʒ��� �ڵ带 ���
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // �÷��̾ �о�� ���� 0���� ����
                playerRb.velocity = Vector2.zero;
            }*/

            gameObject.SetActive(false);

            
        }
    }

    



}
