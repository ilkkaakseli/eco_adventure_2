using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string sceneName;

    private static int scoreLevel1;

    private static int scoreLevel2;

    public bool levelOneComplete = false;
    public bool levelTwoComplete = false;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        scoreLevel1 = 0;
        scoreLevel2 = 0;
    }

    private void Update()
    {
        if (levelOneComplete)
        {
            SetHighScoreLevel1();
        } else if (levelTwoComplete){
            SetHighScoreLevel2();
        }
    }

    public static void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void AddScore(int points)
    {
        if (sceneName == "Level1_CoalMine")
        {
            scoreLevel1 += points;
        }
        else if (sceneName == "Level2")
        {
            scoreLevel2 += points;
        }
    }

    public void DeleteScoreLevel1()
    {
        PlayerPrefs.DeleteKey("ScoreTrashLevel1");
    }
    public void DeleteScoreLevel2()
    {
        PlayerPrefs.DeleteKey("ScoreTrashLevel2");
    }

    public static int GetScoreLevel1()
    {
        return scoreLevel1;
    }

    public static int GetScoreLevel2()
    {
        return scoreLevel2;
    }

    public static void SetHighScoreLevel1()
    {
        int highscore = PlayerPrefs.GetInt("ScoreTrashLevel1");
        if(highscore < GetScoreLevel1())
        {
            PlayerPrefs.SetInt("ScoreTrashLevel1", GetScoreLevel1());
            PlayerPrefs.Save();
        }
    }

    public static void SetHighScoreLevel2()
    {
        int highscore = PlayerPrefs.GetInt("ScoreTrashLevel2");
        if (highscore < GetScoreLevel2())
        {
            PlayerPrefs.SetInt("ScoreTrashLevel2", GetScoreLevel2());
            PlayerPrefs.Save();
        }
    }
}
