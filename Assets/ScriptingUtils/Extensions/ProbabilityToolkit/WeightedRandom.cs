using System.Collections.Generic;
using UnityEngine;

public static class WeightedRandom
{

    public static T SelectFromList<T>(params T[] list) where T : IWeightedChanceItem
    {
        var maxRand = 0f;
        for (int i = 0; i < list.Length; i++)
        {
            maxRand += list[i].ChanceWeight;
        }

        var random = Random.Range(0, maxRand);

        for (int i = 0; i < list.Length; i++)
        {
            if (random < list[i].ChanceWeight)
            {
                return list[i];
            }

            random -= list[i].ChanceWeight;
        }
        return list[0];
    }

    public static T Select<T>(params T[] list) where T : IWeightedChanceItem
    {
        return SelectFromList<T>(list);
    }

    public static T[] SelectSome<T>(int howMany, params T[] list) where T : IWeightedChanceItem
    {
        var output = new T[howMany];
        var listOfItems = new List<T>(list);
        for (int i = 0; i < howMany; i++)
        {
            var s = Select(listOfItems.ToArray());
            listOfItems.Remove(s);
            output[i] = s;
        }

        return output;
    }
    

}
