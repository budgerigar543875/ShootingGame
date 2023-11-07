using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] int energy;
    [SerializeField] Vector3 velocity;
    [SerializeField] bool isInvincible;
    [SerializeField] GameObject explodePrefab;
    [SerializeField] GameObject hitMissilePrefab;
    [SerializeField] int score;

    public virtual bool IsInvincible
    {
        get { return isInvincible; }
        set { isInvincible = value; }
    }

    public virtual int Energy
    {
        get { return energy; }
        set { energy = value; }
    }

    public virtual Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public bool IsAlive
    {
        get
        {
            return energy > 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        if (!isInvincible && layer == LayerMask.NameToLayer("PlayerMissile"))
        {
            energy -= 1;
        }
        else if (layer == LayerMask.NameToLayer("Player"))
        {
            energy = 0;
        }
        if (!IsAlive)
        {
            Instantiate(explodePrefab, transform.position, explodePrefab.transform.rotation);
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScore(score);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitMissilePrefab, transform.position, transform.rotation);
        }
    }

    protected bool IsOutsideTop(Vector3 position)
    {
        return PositionChecker.IsOutsideTop(position);
    }

    protected bool IsOutsideLeft(Vector3 position)
    {
        return PositionChecker.IsOutsideLeft(position);
    }

    protected bool IsOutsideRight(Vector3 position)
    {
        return PositionChecker.IsOutsideRight(position);
    }

    protected bool IsOutsideBottom(Vector3 position)
    {
        return PositionChecker.IsOutsideBottom(position);
    }
}
