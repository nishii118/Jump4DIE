using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : Panel
{
    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;
    public void OnClickExitButton()
    {
        PanelManager.Instance.CloseAll();

    }

    public void OnClickBackgroundMusicBtn()
    {
        //AudioManager.Instance.ToggleBackgroundMusicState();
        
    }

    public void OnClickSFXBtn()
    {
        //AudioManager.Instance.ToggleSFXMusicState();
    }
}
