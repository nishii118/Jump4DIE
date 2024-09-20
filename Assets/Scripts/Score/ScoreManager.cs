using TMPro;
using UnityEngine;

public class ScoreManager 
{
    public static int Score = 0;
    public static int HighScore = 0;
    public static void AddScore(int amount)
    {
        Score += amount;
        HighScoreUpdate();
        Messenger.Broadcast(EventKey.OnChangeScore);
    }
    public static void SetScore(int value)
    {
        Score = value;
        HighScoreUpdate();
        Messenger.Broadcast(EventKey.OnChangeScore);
    }

    public static void SetHighScore()
    {
        Messenger.Broadcast(EventKey.OnChangeHighScore);
    }
    public static void HighScoreUpdate()
    {
        if (HighScore < Score)
        {
            HighScore = Score;
            //Messenger.Broadcast(EventKey.OnChangeHighScore);
        }
    }
    public static void ResetScore()
    {
        Score = 0;
        Messenger.Broadcast(EventKey.OnChangeScore);
    }
}
