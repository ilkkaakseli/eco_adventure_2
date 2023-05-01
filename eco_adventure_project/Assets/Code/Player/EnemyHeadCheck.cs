using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHeadCheck : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D characterRb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCheck>())
        {
            characterRb.velocity = new Vector2(characterRb.velocity.x, 0f);
            characterRb.AddForce(Vector2.up * 300f);
        }
    }
}
