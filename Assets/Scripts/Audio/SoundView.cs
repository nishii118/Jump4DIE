using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundView : MonoBehaviour
{
    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;
    [SerializeField] Image image;

    [SerializeField] private bool isSFX;
    [SerializeField] private bool isBGM;

    private void Update()
    {
        //if (isSFX)
        //{
        //    if (AudioManager.Instance.GetCanPlayiSFX())
        //    {
        //        image.sprite = audioOn;
        //    } else
        //    {
        //        image.sprite = audioOff;
        //    }
        //} else if (isBGM )
        //{
        //    if (AudioManager.Instance.GetCanPlayBGM())
        //    {
        //        image.sprite = audioOn;
        //    }
        //    else
        //    {
        //        image.sprite = audioOff;
        //    }
        //}
    }
}
