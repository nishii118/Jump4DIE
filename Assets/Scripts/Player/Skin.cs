using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] string prefValue; // skin name
    [SerializeField] Sprite spriteBgEnable;
    [SerializeField] Sprite spriteBgUnnable;
    [SerializeField] Sprite spriteTick;
    [SerializeField] Image backgroundImg;
    [SerializeField] Image tickImg;

    private void Start()
    {
        UpdateState();
    }

    private void OnEnable()
    {
        SkinManager.Instance.RegisterSkin(this);
        UpdateState();
    }
    public void UpdateState()
    {
        if (SkinManager.GetSkinState() == prefValue)
        {
            backgroundImg.sprite = spriteBgEnable;
            tickImg.gameObject.SetActive(true);
        }
        else
        {
            backgroundImg.sprite = spriteBgUnnable;
            tickImg.gameObject.SetActive(false);
        }

    }

    public void Switch()
    {

        UpdateState();
    }

    public void ChangeSkin()
    {
        string newSkin = prefValue;
        PlayerPrefs.SetString("SelectedSkin", newSkin);
        //set selectedskin

        SkinManager.Instance.UpdateAllSkins();
    }


}
