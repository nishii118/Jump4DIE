using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingToggleButton : MonoBehaviour
{
    [SerializeField] string prefKey; //Music,Sound,Vibrate(if have), edit in Editor
    [SerializeField] Sprite spriteOn;
    [SerializeField] Sprite spriteOff;
    [SerializeField] Image image; 
    private void Start()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (AudioManager.GetToggleState(prefKey))
        {
            image.sprite = spriteOn;
        }
        else image.sprite = spriteOff;
    }

    public void Toggle()
    {
        AudioManager.ToggleState(prefKey);
        UpdateState();
    }
    private void OnValidate()
    {
        image = GetComponent<Image>();
    }
}
