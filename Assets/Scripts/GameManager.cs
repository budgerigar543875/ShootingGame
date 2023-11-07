using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int stageNo;
    [SerializeField] GameObject player;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] ItemSpawner itemSpawner;
    [SerializeField] Text stageText;
    [SerializeField] Text stageClearText;
    [SerializeField] Text gameOverText;
    [SerializeField] ScoreViewer scoreViewer;
    AudioSource audioSource;
    int timer;
    Player _player;
    ScoreManager scoreManager;

    private void Awake()
    {
        Application.targetFrameRate = ConstValues.FRAME_RATE;
        audioSource = GetComponent<AudioSource>();
        timer = 0;
        _player = player.GetComponent<Player>();
    }

    private void Start()
    {
        audioSource.Play();
        stageText.gameObject.SetActive(false);
        stageClearText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.UpdateScore += scoreViewer.UpdateScore;
        scoreManager.ResetScore();
    }

    private void FixedUpdate()
    {
        if (!_player.IsAlive)
        {
            audioSource.Stop();
            enemySpawner.StopSpawn();
            itemSpawner.StopSpawn();
            gameOverText.gameObject.SetActive(true);
            scoreManager.UpdateScore -= scoreViewer.UpdateScore;
            Invoke("BackToTitle", 3.5f);
        }
        else
        {
            timer++;
            int sec = timer / Application.targetFrameRate;
            if (sec == 0)
            {
                stageText.text = "STAGE " + stageNo;
                stageText.gameObject.SetActive(true);
                itemSpawner.StartSpawn();
            }
            else if (sec == 4)
            {
                stageText.gameObject.SetActive(false);
                enemySpawner.StageNo = stageNo;
                enemySpawner.StartSpawn();
            }
            else if (sec == 110)
            {
                enemySpawner.StopSpawn();
                itemSpawner.StopSpawn();
            }
            else if (sec == 114)
            {
                stageClearText.gameObject.SetActive(true);
            }
            else if(sec == 118)
            {
                stageClearText.gameObject.SetActive(false);
            }
            else if(sec ==120)
            {
                stageNo++;
                timer = 0;
            }
        }
    }

    private void BackToTitle()
    {
        SceneManager.LoadScene("titleScene");
    }
}
