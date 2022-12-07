using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _scoreText/*, _creditText, _adCreditText*/;
    private void Awake()
    {
        instance = this;
    }
    public void ShowGameOverPanel()
    {
        //sound
        _gameOverPanel.SetActive(true);
        GameLoop.instance.UpdateGameOverUI();
    }
    public void ExitToMainMenu()
    {

    }
    public void ShowScore(int score, int credits, int adCredits)
    {
        _scoreText.text = score.ToString();
        /*_creditText.text = credits.ToString();
        _adCreditText.text = adCredits.ToString();*/
    }
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
