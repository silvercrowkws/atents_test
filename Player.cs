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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ��ü�� Enemy���� Ȯ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Player �ı�
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Non_Player"))
        {
            // Player�� �̵��� ����
            CanMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // �浹�� ���� �� Player�� �̵��� �ٽ� ���
        CanMove = true;
    }
}
