using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb2D;

    void Update()
    {
        if (rb2D == null)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        GameManager.LoadLevel("Lose");
    }
}
