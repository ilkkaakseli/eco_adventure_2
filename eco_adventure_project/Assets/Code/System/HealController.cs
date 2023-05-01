using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : MonoBehaviour
{
    [SerializeField] private int healing;
    [SerializeField] private int maxHealing;
    [SerializeField] private LifeController _lifeController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Heal();
            gameObject.SetActive(false);
        }
    }

    public void Heal()
    {
        if(_lifeController.playerHealth < maxHealing)
        {
            _lifeController.playerHealth = _lifeController.playerHealth + healing;
            _lifeController.UpdateHealth();
        }
    }
}
