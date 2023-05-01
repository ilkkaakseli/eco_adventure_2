using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject myGameObject;
    public GameObject movingButtonLeft, movingButtonRight, jumpButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movingButtonLeft.SetActive(false);
            movingButtonRight.SetActive(false);
            jumpButton.SetActive(false);
            myGameObject.SetActive(true); // Enable the GameObject


            Destroy(this.gameObject);
        }
    }
}
