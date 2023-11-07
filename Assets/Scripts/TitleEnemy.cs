using UnityEngine;

public class TitleEnemy : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] bool isInvincible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        bool isAlive = true;
        if (layer == LayerMask.NameToLayer("PlayerMissile"))
        {
            if (!isInvincible)
            {
                isAlive = false;
            }
        } else
        {
            isAlive = false;
        }
        if (isAlive)
        {
            Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
        }
        else
        {
            Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
            Destroy(gameObject);
        }
    }
}
