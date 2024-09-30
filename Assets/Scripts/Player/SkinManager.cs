using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : Singleton<SkinManager>
{
    private List<Skin> skins ;
    private List<Background> backgrounds;

    [SerializeField] PlayerSelection[] players;
    private bool isRegistered = false;

    //private void Awake()
    //{
    //    if (!isRegistered)
    //    {
    //        SceneManager.sceneLoaded += OnSceneLoaded;
    //        isRegistered = true;
    //    }
    //}
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            GeneratePlayerObject();
            Debug.Log("Player generated in GameScene");
        }
    }
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

    public void GeneratePlayerObject()
    {
        PlayerSelection currentPlayer = Array.Find(players, x => x.name == PlayerPrefs.GetString("SelectedSkin"));
        //GameObject newPlayer
        //
        GameObject player = Instantiate(currentPlayer.player);
        player.gameObject.transform.position = new Vector3(0, 5, 0);
        player.gameObject.transform.rotation = Quaternion.identity;
        player.gameObject.SetActive(true);

        Debug.Log("generate: " + player);
    }
}
