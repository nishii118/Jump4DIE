using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAndBackGroundPanel : Panel
{ 
  public void OnClickExitButton()
    {
        SkinManager.Instance.ClearAllSkin();
        SkinManager.Instance.ClearAllBackground();
        PanelManager.Instance.CloseAll();
    } 
    
  public void SelectSkin()
    {

    }
}
