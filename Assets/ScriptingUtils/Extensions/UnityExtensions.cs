using UnityEngine;

public static class UnityExtensions
{
    public static bool CompareLayer(this LayerMask mask, LayerMask compareTo)
    {
        return (compareTo.value & (1 << mask)) > 0;
    }     
    public static bool CompareLayer(this GameObject gameObject, LayerMask compareTo)
    {
        return (compareTo.value & (1 << gameObject.layer)) > 0;
    }       
    public static bool CompareLayer(this Collider2D collider, LayerMask compareTo)
    {
        return (compareTo.value & (1 << collider.gameObject.layer)) > 0;
    }
       
    public static bool CompareLayer(this Collision2D collision, LayerMask compareTo)
    {
        return (compareTo.value & (1 << collision.gameObject.layer)) > 0;
    }


    
}
