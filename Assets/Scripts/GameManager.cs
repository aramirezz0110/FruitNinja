using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score UI References")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Button retryButton;
    private int score;

    [Header("Game Over UI References")]
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    
    private void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
    }
    private void Start()
    {
        UpdateScoreInUI(0);
        retryButton.onClick.AddListener(OnRetryButtonClicked);
    }
    public void IncreaseScore()
    {
        score++;
        if (score > GetHighScore())
        {
            SetHighScore(score);
        }
        UpdateScoreInUI(score);
    }
    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreInUI(score);
    }
    public void BombCutted()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final score: " + score;
    }
    private void UpdateScoreInUI(int value)
    {
        scoreText.text = value.ToString();
        highScoreText.text ="High Score: "+ GetHighScore();
    }
    private int GetHighScore()
    {
        return PlayerPrefs.GetInt(PlayerPrefsNames.Score, 0);
    }
    private void SetHighScore(int value)
    {
        PlayerPrefs.SetInt(PlayerPrefsNames.Score, value);
    }
    private void OnRetryButtonClicked()
    {
        Time.timeScale = 1;
        SceneSwitcher.Instance.LoadGameScene();
    }
}
