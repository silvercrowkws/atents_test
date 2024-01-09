using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // 키 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal");

        Debug.Log("Vertical Input: " + verticalInput);
        Debug.Log("Horizontal Input: " + horizontalInput);

        // 이동 방향 계산
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize(); // 대각선 이동 시 이동 속도를 일정하게 유지

        // 플레이어 이동
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
