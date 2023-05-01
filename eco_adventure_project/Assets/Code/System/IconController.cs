using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconController : MonoBehaviour
{
    [SerializeField] public int levelOneMaxTrash;
    [SerializeField] public int levelTwoMaxTrash;

    public GameObject levelOneGrey;
    public GameObject levelOneColor;
    public GameObject levelTwoGrey;
    public GameObject levelTwoColor;
    public GameObject levelTwoLocked;

    private void Update()
    {
        LevelOneIconUpdate();
        LevelTwoIconUpdate();
    }

    private void LevelOneIconUpdate()
    {
        if (!PlayerPrefs.HasKey("ScoreTrashLevel1"))
        {
            PlayerPrefs.SetInt("ScoreTrashLevel1", 0);
        } else
        {
            if (levelOneMaxTrash <= PlayerPrefs.GetInt("ScoreTrashLevel1"))
            {
                levelOneGrey.SetActive(false);
                levelOneColor.SetActive(true);
            }
        }

        
    }

    private void LevelTwoIconUpdate()
    {
        if (!PlayerPrefs.HasKey("ScoreTrashLevel2"))
        {
            PlayerPrefs.SetInt("ScoreTrashLevel2", 0);
        }

        if (PlayerPrefs.GetInt("ScoreTrashLevel1") > 0)
        {
            levelTwoLocked.SetActive(false);
            levelTwoGrey.SetActive(true);
        }
        if (levelTwoMaxTrash <= PlayerPrefs.GetInt("ScoreTrashLevel2"))
        {
            levelTwoGrey.SetActive(false);
            levelTwoColor.SetActive(true);   
        }
    }
}
