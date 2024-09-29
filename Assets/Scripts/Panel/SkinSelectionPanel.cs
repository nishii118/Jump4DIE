using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelectionPanel : MonoBehaviour
{
    public void OnClickBackgroundSelectionBtn()
    {
        PanelManager.Instance.CloseAll();
        PanelManager.Instance.OpenPanel("BlurPanel");
        PanelManager.Instance.OpenPanel("BackgroundSelectionPanel");
    }
}
