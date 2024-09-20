
using UnityEngine;

public class PausePanel : Panel
{
    //[SerializeField] Player player;
    public void OnClickExitBtn()
    {
        Time.timeScale = 1f;
        Debug.Log("Onclick Exit BTN on PausePanel");
        PanelManager.Instance.OpenPanel("GamePlayUI");
        Close();
        //player.CanFly = true;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        PanelManager.Instance.CloseAll();
        PanelManager.Instance.OpenPanel("GamePlayUI");
        //PanelManager.Instance.CloseAll(); 
        Debug.Log("Reload curren scence");
        GameManager.Instance.ReloadCurrentScene();
        //player.CanFly = true;

        //reset score
        ScoreManager.ResetScore();
    }

    public void OnClickHomeButton()
    {
        GameManager.Instance.LoadSceneByName("MainMenu");
    }
}
