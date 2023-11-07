using System.Collections;
using UnityEngine;

public class TitleCharacter : MonoBehaviour
{
    [SerializeField] GameObject laser;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Animator ani = GetComponent<Animator>();
            ani.SetBool("attack", false);
            ani.SetBool("damage", true);
            StartCoroutine(DestroyCharacter());
        }
    }

    private IEnumerator DestroyCharacter()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void FireAnimationEnter()
    {
        Instantiate(laser, transform.position + new Vector3(2.5f, 0f, 0f), laser.transform.rotation).GetComponent<Missile>();
    }

    private void FireAnimationCompleted()
    {
        Animator ani = GetComponent<Animator>();
        ani.SetBool("attack", true);
        ani.SetBool("damage", false);
        GetComponent<Rigidbody2D>().velocity = new Vector3(7f, 0f, 0f);
    }

    private void DefaultAnimationEnter()
    {
        // NOP
    }

    private void HurtAnimationEnter()
    {
        // NOP
    }
}
