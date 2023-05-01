using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetHighScore : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public string levelOneName;
    [SerializeField] public string levelTwoName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && SceneManager.GetActiveScene().name == levelOneName)
        {
            gameManager.levelOneComplete = true;
        }
        else if(collision.CompareTag("Player") && SceneManager.GetActiveScene().name == levelTwoName)
        {
            gameManager.levelTwoComplete = true;
        }
    }
}
