using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    private void HitAnimationCompleted()
    {
        Destroy(gameObject);
    }
}
