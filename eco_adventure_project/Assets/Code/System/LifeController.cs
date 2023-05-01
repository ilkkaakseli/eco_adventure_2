using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public int playerHealth;

    [SerializeField] private Image[] lives;

    [SerializeField]
    private Rigidbody2D characterRb;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if(i < playerHealth)
            {
                lives[i].color = Color.white;
            }
            else
            {
                lives[i].color = Color.black;
            }
        }
    }

    private void Update()
    {
        if (playerHealth <= 0 && characterRb != null)
        {
            Destroy(characterRb.gameObject);
        }
    }

}
