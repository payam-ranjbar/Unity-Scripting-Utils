using UnityEngine;

public static class VectorExtensions
{
    public static float GetRandomBetween(this Vector2 vector) => Random.Range(vector.x, vector.y);

    public static Vector3 GetWithXZ(this Vector3 vector3, float x, float z)
    {
        return new Vector3(x, vector3.y, z);
    }
    public static Vector3 GetWithY(this Vector3 vector3, float y)
    {
        return new Vector3(vector3.x, y, vector3.z);
    }
    public static Vector3 GetWithZ(this Vector3 vector3, float z)
    {
        return new Vector3(vector3.x, vector3.y, z);
    }
    public static Vector3 GetWithX(this Vector3 vector3, float x)
    {
        return new Vector3(x, vector3.y, vector3.z);
    }
    public static Vector2 GetWithX(this Vector2 vector2, float x)
    {
        return new Vector2(x, vector2.y);
    }
    public static Vector3 GetWith(this Vector3 vector3, float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    public static Vector2 GetWith(this Vector2 vector2, float x, float y)
    {
        return new Vector2(x, y);
    }
    
    
    public static Vector3 MultXZ(this Vector3 vector3, float multiplier)
    {
        return new Vector3(vector3.x * multiplier, vector3.y, vector3.z * multiplier);
    }

    public static Vector3 GetWithY(this Vector3 vector3, Vector3 v)
    {
        return new Vector3(vector3.x, v.y, vector3.z);
    }
}
