using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _scoreText.text = "0";
    }
    public void AnimateScoreUpdate(int previousScore, int newScore)
    {
        _animator.SetTrigger("scale");
        StartCoroutine(CountScore(previousScore, newScore));
    }
    private IEnumerator CountScore(int previousScore, int newScore)
    {
        while(previousScore < newScore)
        {
            previousScore += 1;
            _scoreText.text = previousScore.ToString();
            yield return new WaitForSeconds(0.05f);
        }
        _scoreText.text = newScore.ToString();
    }
}
