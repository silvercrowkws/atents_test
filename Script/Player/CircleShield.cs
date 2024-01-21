using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShield : RecycleObject
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
