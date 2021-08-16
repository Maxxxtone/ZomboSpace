using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    YandexSDK yandexSDK;
    private void Start()
    {
        yandexSDK = YandexSDK.instance;
        yandexSDK.onRewardedAdReward += GameLoop.instance.Reward;
    }
}
