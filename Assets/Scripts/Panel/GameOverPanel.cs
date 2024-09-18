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
    }
}
