using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    [SerializeField] private PlayerResources _playerResources;
    private TextMeshProUGUI _text;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = _playerResources.HighScore.ToString();
    }
}
