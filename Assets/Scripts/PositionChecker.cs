
using UnityEngine;

public static class PositionChecker
{
    public static bool IsOutsideTop(Vector3 position)
    {
        return position.y > 12f;
    }

    public static bool IsOutsideLeft(Vector3 position)
    {
        return position.x < -18f;
    }

    public static bool IsOutsideRight(Vector3 position)
    {
        return position.x > 20f;
    }

    public static bool IsOutsideBottom(Vector3 position)
    {
        return position.y < -12f;
    }
}
