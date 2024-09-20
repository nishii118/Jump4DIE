using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : Panel
{
    #region SingleTon
    public static GameOverPanel Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public void ReloadGame()
    {
        GameManager.Instance.ReloadCurrentScene();
        Time.timeScale = 1f;

        ScoreManager.ResetScore();
    }

    public void OnClickHomeButton()
    {
        GameManager.Instance.LoadSceneByName("MainMenu");
    }
}
