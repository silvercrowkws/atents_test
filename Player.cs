using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Ű �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        Debug.Log("Vertical Input: " + verticalInput);
        Debug.Log("Horizontal Input: " + horizontalInput);

        // �̵� ���� ���
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize(); // �밢�� �̵� �� �̵� �ӵ��� �����ϰ� ����

        // �÷��̾� �̵�
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
