using UnityEngine;

public class Enemy1 : EnemyBase
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Velocity;
    }

    private void FixedUpdate()
    {
        if (IsOutsideLeft(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
