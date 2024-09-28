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
        //Debug.Log("Click bg music btn");
        //AudioManager.ToggleState("Music");
        
    }

    public void OnClickSFXBtn()
    {
        //AudioManager.ToggleState("Sound");
    }
}
