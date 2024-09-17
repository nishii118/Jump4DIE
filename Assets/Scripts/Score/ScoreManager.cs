using TMPro;
using UnityEngine;

public class ScoreManager 
{
    public static int Score;
    public static void AddScore(int amount)
    {
        Score += amount;
        Messenger.Broadcast(EventKey.OnChangeScore);
    }
    public static void SetScore(int value)
    {
        Score = value;
        Messenger.Broadcast(EventKey.OnChangeScore);
    }
}
