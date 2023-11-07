using UnityEngine;

public class Enemy3 : EnemyBase
{
    [SerializeField] GameObject missile;

    Rigidbody2D body;
    bool isShooted;
    int spd;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isShooted = false;
        spd = (int)Velocity.x;
    }

    public override Vector3 Velocity {
        get => base.Velocity; 
        set
        {
            base.Velocity = value;
            spd = (int)value.x;
        }
    }

    private void FixedUpdate()
    {
        if (!isShooted)
        {
            spd = (int)(spd * 0.95);
            if (spd == 0)
            {
                Instantiate(missile, transform.position - new Vector3(1f, 0f, 0f), transform.rotation);
                isShooted = true;
            }
        }
        else
        {
            spd = 20;
        }
        body.velocity = new Vector3(spd, Velocity.y, 0f);
        if (IsOutsideTop(transform.position) || IsOutsideRight(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
