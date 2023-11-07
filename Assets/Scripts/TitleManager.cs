using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Text messageText;
    [SerializeField] ScoreViewer scoreViewer;
    [SerializeField] GameObject character;

    ScoreManager scoreManager;
    bool showMessage;

    private void Awake()
    {
        showMessage = false;
    }

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.UpdateScore += scoreViewer.UpdateScore;
        scoreManager.AddScore(0);
    }

    private void Update()
    {
        if (!showMessage && character.IsDestroyed())
        {
            showMessage = true;
            StartCoroutine(MessageFlashing());
        }
        if(showMessage)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                scoreManager.UpdateScore -= scoreViewer.UpdateScore;
                SceneManager.LoadScene("StageScene");
            }
        }
    }

    private IEnumerator MessageFlashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.9f);
            messageText.enabled = !messageText.enabled;
        }
    }
}
