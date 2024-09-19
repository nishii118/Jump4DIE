using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnClickSettingButton()
    {
        Debug.Log("On click setting btn");
        PanelManager.Instance.OpenPanel("BlurPanel");
        PanelManager.Instance.OpenPanel("SettingPanel");

    }

    public void OnClickSkinAndBackgroundButton()
    {
        PanelManager.Instance.OpenPanel("BlurPanel");
        PanelManager.Instance.OpenPanel("SkinAndBackgroundPanel");

    }

    public void OnClickPlayButton()
    {
        GameManager.Instance.LoadSceneByName("GameScene");
        Time.timeScale = 1f;
    }
}
