using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int enemyDamage;

    [SerializeField] private LifeController _lifeController;

    public PhysicsMover playerMover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMover.KBCounter = playerMover.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMover.knockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerMover.knockFromRight = false;
            }
            Damage();
        }
    }

    public void Damage()
    {
        _lifeController.playerHealth = _lifeController.playerHealth - enemyDamage;
        _lifeController.UpdateHealth();
    }
}
