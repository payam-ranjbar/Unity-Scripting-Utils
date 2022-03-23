using UnityEngine;
using Random = UnityEngine.Random;

public static class WeightedRandom
{
    public static bool Luck(float chance)
    {
        chance = Mathf.Clamp01(chance);
        var value = Random.value;


        return value <= chance;
    }
}