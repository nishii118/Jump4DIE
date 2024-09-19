
using UnityEngine;
using UnityEngine.UI;

public class GamePlayPanel : Panel
{
    //[SerializeField] Player player;
    #region SingleTon
    public static GamePlayPanel Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] Button stopBtn;
    public void OnClickStopBtn()
    {
        //player.CanFly = false;
        Time.timeScale = 0f; // stop the game 

        Debug.Log("Onclick stop btn");
        PanelManager.Instance.OpenPanel("PausePanel");
        Close();
    }
}
