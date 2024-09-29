using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSelectionPanel : MonoBehaviour
{
    public void OnClickSkinSelectionBtn()
    {
        PanelManager.Instance.CloseAll();
        PanelManager.Instance.OpenPanel("BlurPanel");
        PanelManager.Instance.OpenPanel("SkinSelectionPanel");
    }
}
