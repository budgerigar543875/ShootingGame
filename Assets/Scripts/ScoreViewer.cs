using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;

    public void UpdateScore(int score, int highScore)
    {
        scoreText.text = string.Format("Score {0}", score);
        highScoreText.text = string.Format("HighScore {0}", highScore);
    }
}
