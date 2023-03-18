using UnityEngine;

public static class HelperFunctions
{
    public static Vector3 Multiply(this Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    public static Vector3 Multiply(this Vector3 a, float x, float y, float z)
    {
        return new Vector3(a.x * x, a.y * y, a.z * z);
    }
}
