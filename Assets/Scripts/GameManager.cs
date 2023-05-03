using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public int score;
    public Text hScoreText;
    public int hScore;
    public GameObject gameOverPanel, startPanel;

    public void SetScore(int value)
    {
        score += value;
        ScoreText.text = "Score: "+ score.ToString();
    }
    public void GameOver()
    {
        startPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        if (score > hScore)
        {
            PlayerPrefs.SetInt("hScore", score);
            hScoreText.text = "New H-Score: " + score.ToString();
        }

        Time.timeScale = 0;
    }
}
