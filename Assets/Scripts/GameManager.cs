using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject congratulationPanel, gameoverPanel;

    public bool isPlayed;
    public float timer;
    public int levelNumber;
    public int numberOfPlatforms;

    public List<GameObject> platforms = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;

        levelNumber = PlayerPrefs.GetInt("LevelNumber", 1);
        numberOfPlatforms = PlayerPrefs.GetInt("Level " + GameManager.instance.levelNumber, 500);
    }

    private void Update()
    {
        if (isPlayed)
        {
            timer += Time.deltaTime;
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void onPlayerFail()
    {
        Destroy(Player.instance.gameObject);

        changeUIText();

        gameoverPanel.SetActive(true);        
        isPlayed = false;

        PlayerPrefs.SetInt("LevelNumber", 1);
        
    }

    public void onPlayerSuccess()
    {
        changeUIText();

        congratulationPanel.SetActive(true);
        isPlayed = false;

        
    }


    private void changeUIText()
    {
        int bestTime = PlayerPrefs.GetInt("BestTime " + levelNumber, 0);
        if (timer <= bestTime || bestTime == 0)
        {
            PlayerPrefs.SetFloat("BestTime " + levelNumber, timer);
        }

        //Set Timer
        GameUI.instance.CON_time.text = Mathf.Round(timer).ToString();
        GameUI.instance.CON_bestTime.text = Mathf.Round(PlayerPrefs.GetFloat("BestTime " + levelNumber, 0)).ToString();

        GameUI.instance.OVER_time.text = Mathf.Round(timer).ToString();

        GameUI.instance.CON_LevelNum.text = levelNumber + "";
        GameUI.instance.OVER_LevelNum.text = levelNumber + "";
    }

}
