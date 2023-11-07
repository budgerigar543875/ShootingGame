using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] Vector3 velocity;
 
    public Vector3 Velocity
    {
        get => velocity;
        set => velocity = value;
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void FixedUpdate()
    {
        if (PositionChecker.IsOutsideRight(transform.position))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag != "Laser")
        {
            Destroy(gameObject);
        }
    }
}
