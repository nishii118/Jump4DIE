
using UnityEngine;

public class PausePanel : Panel
{
    public void OnClickExitBtn()
    {
        Time.timeScale = 1f;
        Debug.Log("Onclick Exit BTN on PausePanel");
        PanelManager.Instance.OpenPanel("GamePlayUI");
        Close();
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        PanelManager.Instance.CloseAll();
        PanelManager.Instance.OpenPanel("GamePlayUI");
        //PanelManager.Instance.CloseAll(); 
        Debug.Log("Reload curren scence");
        GameManager.Instance.ReloadCurrentScene();
    }
}
