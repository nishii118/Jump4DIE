using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.SetHighScore();
    }
    public void OnClickSettingButton()
    {
        Debug.Log("On click setting btn");
        PanelManager.Instance.OpenPanel("BlurPanel");
        PanelManager.Instance.OpenPanel("SettingPanel");

    }

    public void OnClickSkinAndBackgroundButton()
    {
        Debug.Log("gen blur panel");
        PanelManager.Instance.OpenPanel("BlurPanel");
        Debug.Log("gen main panel");
        PanelManager.Instance.OpenPanel("SkinSelectionPanel");

    }

    public void OnClickPlayButton()
    {
        GameManager.Instance.LoadSceneByName("GameScene");
        Time.timeScale = 1f;

        ScoreManager.ResetScore();


        //SceneManager.sceneLoaded += OnGameSceneLoaded;
        //SkinManager.Instance.GeneratePlayerObject();
        //Debug.Log("gen player");
    }

    
}
