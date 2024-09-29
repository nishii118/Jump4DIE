using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelectionPanel : MonoBehaviour
{
    public void OnClickBackgroundSelectionBtn()
    {
        SkinManager.Instance.ClearAllSkin();

        PanelManager.Instance.CloseAll();
        PanelManager.Instance.OpenPanel("BlurPanel");
        PanelManager.Instance.OpenPanel("BackgroundSelectionPanel");
    }
}
