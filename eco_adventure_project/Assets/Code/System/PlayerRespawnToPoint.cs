using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnToPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private LifeController lifeController;
    [SerializeField]
    private DamageController damageController;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damageController.Damage();
            player.transform.position = respawnPoint.position;
        }
    }
}
