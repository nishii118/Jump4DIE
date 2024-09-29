using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : Singleton<SkinManager>
{
    private List<Skin> skins ;
    private List<Background> backgrounds;
    
    private void Start()
    {
        skins = new List<Skin> ();
        backgrounds = new List<Background> ();
        PlayerPrefs.SetString("SelectedSkin", "Penguine");
        PlayerPrefs.SetString("SelectedBackground", "The Snow"); ;
    }

    public void RegisterSkin(Skin skin)
    {
        if (!skins.Contains(skin))
        {
            skins.Add(skin);
            skin.UpdateState();
        }
    }

    public void ClearAllSkin()
    {
        skins.Clear ();
    }

    public void ClearAllBackground()
    {
        backgrounds.Clear ();
    }
    public void RegisterBackground(Background background)
    {
        if (!backgrounds.Contains(background))
        {
            backgrounds.Add(background);
            background.UpdateState();
        }
    }
    public void UpdateAllSkins()
    {
        foreach (Skin skin in skins)
        {
            skin.UpdateState();
        }
    }

    public void UpdateAllBackgrounds()
    {
        foreach(Background background in backgrounds)
        {
            background.UpdateState();
        }
    }
    public static string GetSkinState() 
    {
        return PlayerPrefs.GetString("SelectedSkin", "Penguine");
    }
    public static string GetBackgroundState() 
    {
        return PlayerPrefs.GetString("SelectedBackground", "The Snow");
    }

    //public static void ChangeSkin(string value)
    //{
    //    string newSkin = value;
    //    PlayerPrefs.SetString("SelectedSkin", newSkin);
    //    //set selectedskin
    //}
    //public static void ChangeBackground(string value)
    //{
    //    string newBackground = value;
    //    PlayerPrefs.SetString("Selected", newBackground);
    //}
}
