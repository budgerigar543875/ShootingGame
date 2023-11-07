using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int highScore;

    static ScoreManager instance = null;

    public delegate void UpdateScoreEventHandler(int  score, int highScore);
    public UpdateScoreEventHandler UpdateScore;

    public int Score {  get; private set; }

    public int HighScore { get => highScore; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        Score = 0;
        RaiseUpdateScore();
    }

    public void AddScore(int score)
    {
        Score += score;
        highScore = Math.Max(HighScore, Score);
        if (UpdateScore != null)
        {
            UpdateScore(Score, HighScore);
        }
        RaiseUpdateScore();
    }

    private void RaiseUpdateScore()
    {
        if (UpdateScore != null)
        {
            UpdateScore(Score, HighScore);
        }
    }
}
