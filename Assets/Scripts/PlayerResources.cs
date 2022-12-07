using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";
    public int HighScore
    {
        get
        {
            if(PlayerPrefs.HasKey(HighScoreKey))
                return PlayerPrefs.GetInt(HighScoreKey);
            return 0;
        }
        set
        {
            PlayerPrefs.SetInt(HighScoreKey, value);
        }
    }
}
