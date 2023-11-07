using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField] Vector3 velocity;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void FixedUpdate()
    {
        if (PositionChecker.IsOutsideLeft(transform.position))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
