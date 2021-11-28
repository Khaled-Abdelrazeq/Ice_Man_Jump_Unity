using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
  public void onPlayButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }  

    public void onQuitButtonClicked()
    {
        Application.Quit();
    }

    private void Awake()
    {
        PlayerPrefs.SetInt("LevelNumber", 1);

        PlayerPrefs.SetInt("Level 1", 100);
        PlayerPrefs.SetInt("Level 2", 150);
        PlayerPrefs.SetInt("Level 3", 200);
        PlayerPrefs.SetInt("Level 4", 250);
        PlayerPrefs.SetInt("Level 5", 300);
        PlayerPrefs.SetInt("Level 6", 350);
        PlayerPrefs.SetInt("Level 7", 400);
        PlayerPrefs.SetInt("Level 8", 450);
        PlayerPrefs.SetInt("Level 9", 500);
        PlayerPrefs.SetInt("Level 10", 600);
    }
}
