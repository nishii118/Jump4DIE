using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] string prefValue;
    [SerializeField] Image tickImg;

    private void Start()
    {
        UpdateState();
    }

    private void OnEnable()
    {
        SkinManager.Instance.RegisterBackground(this);
        UpdateState();
    }

    public void UpdateState()
    {
        if (SkinManager.GetBackgroundState() == prefValue)
        {
            tickImg.gameObject.SetActive(true);
        } else
        {
            tickImg.gameObject.SetActive(false);
        }
    }

    public void ChangeBackground()
    {
        string newBackground = prefValue;
        PlayerPrefs.SetString("SelectedBackground", newBackground);

        SkinManager.Instance.UpdateAllBackgrounds();
    }
}
