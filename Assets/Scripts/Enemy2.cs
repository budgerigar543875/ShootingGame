using UnityEngine;

public class Enemy2 : EnemyBase
{
    Rigidbody2D body;
 
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Velocity;
    }

    private void FixedUpdate()
    {
        float y = body.velocity.y;
        if (transform.position.y > 8.75f)
        {
            y = -Mathf.Abs(y);
        }
        if (transform.position.y < -8.75f)
        {
            y = Mathf.Abs(y);
        }
        body.velocity = new Vector3(Velocity.x, y, Velocity.z);
        if (IsOutsideLeft(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
