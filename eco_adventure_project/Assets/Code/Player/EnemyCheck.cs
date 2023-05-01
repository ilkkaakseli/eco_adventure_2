using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D characterRb;

    [SerializeField] private LifeController _lifeController;

    [SerializeField] private DamageController _damageController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            _damageController.Damage();
        }

        if (_lifeController.playerHealth == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
