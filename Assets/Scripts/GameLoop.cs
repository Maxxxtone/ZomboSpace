using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLoop : MonoBehaviour
{
    public static GameLoop instance;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    private Transform _heroPosition;
    public int score;
    private const int ScoreBoost = 10;
    private bool canWatchAd;
    public Transform HeroPosition { get => _heroPosition; private set => _heroPosition = value; }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        canWatchAd = true;
        HeroPosition = GameObject.FindGameObjectWithTag("Player").transform;    
    }
    public void UpdateScore()
    {
        _scoreUpdater.AnimateScoreUpdate(score, ScoreBoost + score);
        score += ScoreBoost;
    }
    public void UpdateGameOverUI()
    {
        UIManager.instance.ShowScore(score, score / 10, score / 20);
    }
    public void Reward(string rewardType = "coins")
    {
        print("try");
        if (canWatchAd)
        {
            int credits = 0;
            if (PlayerPrefs.HasKey("credits"))
                credits = PlayerPrefs.GetInt("credits");
            PlayerPrefs.SetInt("credits", credits + score / 20);
            UIManager.instance.ShowScore(score, score / 10, 0);
            canWatchAd = false;
        }
        print(PlayerPrefs.GetInt("credits"));
    }
}
