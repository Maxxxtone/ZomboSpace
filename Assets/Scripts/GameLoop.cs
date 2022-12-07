using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLoop : MonoBehaviour
{
    public static GameLoop instance;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private PlayerResources _resources;
    [SerializeField] private AdManager _adManager;
    private Transform _heroPosition;
    public int score;
    private const int ScoreBoost = 10;
    private bool canWatchAd, isGameOver;
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
        if (!isGameOver)
        {
            _scoreUpdater.AnimateScoreUpdate(score, ScoreBoost + score);
            score += ScoreBoost;
            if (score > _resources.HighScore)
                _resources.HighScore = score;
        }
    }
    public void UpdateGameOverUI()
    {
        UIManager.instance.ShowScore(score, score / 10, score / 20);
        isGameOver = true;
        _adManager.ShowInterstitialAd();
    }
    public void Reward(string rewardType = "coins")
    {
        if (canWatchAd)
        {
            int credits = 0;
            if (PlayerPrefs.HasKey("credits"))
                credits = PlayerPrefs.GetInt("credits");
            PlayerPrefs.SetInt("credits", credits + score / 20);
            UIManager.instance.ShowScore(score, score / 10, 0);
            canWatchAd = false;
        }
    }
    public void StopCountScore() => isGameOver = true;
}
