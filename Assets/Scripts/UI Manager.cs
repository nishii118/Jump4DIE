using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject perfectPointUI;
    public void ShowPerfectUI()
    {
        perfectPointUI.SetActive(true);

        StartCoroutine(TurnOffPerfectPointUIDelay(0.5f));
    }

    IEnumerator TurnOffPerfectPointUIDelay(float time)
    {
        yield return new WaitForSeconds(time);

        perfectPointUI.SetActive(false);
    }
}
