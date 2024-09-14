using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    //class này có thể không cần để singleton và monobehavior, để biến score static cũng được
    //chẳng hạn gọi hàm static UpdateScore,trong đó sẽ phát sự kiện OnChangeScore, 
    // tạo một thằng ScoreView listen cái Event đó => Clean

    /*
    private static int Score;
    public static void AddScore(int amount)
    {
        Score += amount;
        Messenger.Broadcast(EventKey.OnChangeScore);
    }
    public static void SetScore(int value)
    {
        Score= value;
        Messenger.Broadcast(EventKey.OnChangeScore);
    }

    public class ScoreView:MonoBehaviour //thấy clean hơn không? Thằng nào muốn hiện điểm thì cứ add component này vào là xong,kiểu game over cũng có hiện score chẳng hạn
    {
        [SerializeField] TextMeshProUGUI scoreTxt;
        private void OnEnable()
        {
            OnChangeScore();
            Messenger.AddListener(EventKey.OnChangeScore, OnChangeScore);
        }

        private void OnChangeScore()
        {
            scoreTxt.SetText(ScoreManager.Score.ToString());
        }

        private void OnDisable()
        {
            Messenger.RemoveListener(EventKey.OnChangeScore, OnChangeScore);
        }
        
        
        private void OnValidate()
        {
            scoreTxt=GetComponent<TextMeshProUGUI>();
        }
    }
    */

    [SerializeField] TextMeshProUGUI scoreTxt;

    private int score;
    private bool isGetPerfectPoints = false;

    public void SetIsGetPerfectPoints() {  isGetPerfectPoints = true; }
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
        if (isGetPerfectPoints) { score += scoreValue; }
        isGetPerfectPoints = false;
    }
}
