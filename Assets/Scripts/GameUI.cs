using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public TextMeshProUGUI CON_time;
    public TextMeshProUGUI CON_bestTime;
    public TextMeshProUGUI OVER_time;
    public TextMeshProUGUI OVER_bestTime;
    public TextMeshProUGUI CON_LevelNum;
    public TextMeshProUGUI OVER_LevelNum;


    int level;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        level = PlayerPrefs.GetInt("LevelNumber", 1);
    }

    public void onRestartButtonClicked()
    {        
        SceneManager.LoadScene("GameScene");
    }

    public void onNextButtonClicked()
    {
        

        PlayerPrefs.SetInt("LevelNumber", level + 1);

        print(level);
        SceneManager.LoadScene("GameScene");
    }

    public void onCloseButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
