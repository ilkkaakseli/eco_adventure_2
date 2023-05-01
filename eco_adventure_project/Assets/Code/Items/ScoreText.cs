using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    public static string sceneName;
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Update()
    {
        if (sceneName == "Level1_CoalMine")
        {
            scoreText.text = ": " + GameManager.GetScoreLevel1();
        }

        else if (sceneName == "Level2")
        {
            scoreText.text = ": " + GameManager.GetScoreLevel2();
        }
    }
}
