using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleLetter : MonoBehaviour
{
    [SerializeField] float delay;
    Text txt;
    string letter;

    private void Awake()
    {
        txt = GetComponent<Text>();
        letter = txt.text;
        txt.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerMissile"))
        {
            StartCoroutine(ShowLetter());
        }
    }

    IEnumerator ShowLetter()
    {
        yield return new WaitForSeconds(delay);
        txt.text = letter;
    }
}
