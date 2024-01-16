using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    private int score;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "Highest Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void UpdateHighScore()
    {
        highScore = score;
        highScoreText.text = "Highest Score: " + highScore.ToString();
        PlayerPrefs.SetInt("High Score", highScore);
    }

    public void UpdateScore(int n)
    {
        score = score + n;
        scoreText.text = "Score: " + score.ToString();
        if (score > highScore)
        {
            UpdateHighScore();
        }
    }
}
