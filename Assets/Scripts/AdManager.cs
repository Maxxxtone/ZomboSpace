using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private bool _showAdOnStart = false;
    private YandexSDK yandexSDK;
    private void Start()
    {
        yandexSDK = YandexSDK.instance;
        yandexSDK.onRewardedAdReward += GameLoop.instance.Reward;
        if(_showAdOnStart)
            yandexSDK.ShowInterstitial();
    }
    public void ShowInterstitialAd() => yandexSDK.ShowInterstitial();
}
