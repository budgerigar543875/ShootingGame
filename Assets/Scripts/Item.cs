using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Vector3 velocity;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void FixedUpdate()
    {
        if (PositionChecker.IsOutsideLeft(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
