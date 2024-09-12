using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] TextMeshProUGUI scoreTxt;

    private int score;

    private void Start()
    {
        score = 0;
        scoreTxt.text = score.ToString();
    }

    private void Update()
    {
        scoreTxt.text = score.ToString();
    }
    public void UpdateScore(int scoreValue)
    {
        score+= scoreValue;
    }
}
