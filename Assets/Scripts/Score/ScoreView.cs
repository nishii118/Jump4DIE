
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour  
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highscoreTxt;
    private void OnEnable()
    {
        OnChangeScore();
        Messenger.AddListener(EventKey.OnChangeScore, OnChangeScore);
        Messenger.AddListener(EventKey.OnChangeHighScore, OnChangeHighScore);
    }

    private void OnChangeHighScore()
    {
        if (highscoreTxt != null)
        {
            highscoreTxt.SetText(ScoreManager.HighScore.ToString());
        }
    }
    private void OnChangeScore()
    {
        scoreTxt.SetText(ScoreManager.Score.ToString());
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(EventKey.OnChangeScore, OnChangeScore);
        Messenger.RemoveListener(EventKey.OnChangeHighScore, OnChangeHighScore);
    }

    
    private void OnValidate()
    {
        //scoreTxt = GetComponent<TextMeshProUGUI>();
        //highscoreTxt = GetComponent<TextMeshProUGUI>();
    }
}
