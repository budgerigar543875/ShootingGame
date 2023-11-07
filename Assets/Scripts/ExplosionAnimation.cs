using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    private void ExplosionAnimationCompleted()
    {
        Destroy(gameObject);
    }
}
