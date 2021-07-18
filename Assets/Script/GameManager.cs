using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public  int score;
    public Text scoreText;
    public Text bestText;
    public Text lastScoreText;
    public Animator gameOverAnim;
    public Text diamondText;
    public int diamondScore;
    public Text mainGameScore;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score = 0;
    }

   
    void Update()
    {
        scoreText.text = score.ToString();
        mainGameScore.text = scoreText.text;
    }

    public void GameOver()
    {
        gameOverAnim.SetTrigger("GameOver");

        lastScoreText.text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        bestText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void RetryGame() //restarting the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CollectDiamond()
    {
        diamondScore++;
        diamondText.text = diamondScore.ToString();
    }
}
