using System;
using System.Collections.Generic;

public static class CollectionExtensions
{
    public static Dictionary<T, TU> BuildFromList<T, TU>(this Dictionary<T, TU> dictionary, TU[] array, Func<TU, T> getKey)
    {
        dictionary = new Dictionary<T, TU>();

        foreach (var element in array)
        {
            var key = getKey(element);

            dictionary.Add(key, element);
        }

        return dictionary;
    }

    public static  bool AddOrOverride<T, TU>(this Dictionary<T, TU> dictionary, TU element, Func<TU, T> getKey)
    {
        dictionary = new Dictionary<T, TU>();
        var key = getKey(element);

        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = element;
            return true;
        }

        dictionary.Add(key, element);

        return false;
    }
    
    public static T GetRandom<T>(this T[] list)
    {
        return list[UnityEngine.Random.Range(0, list.Length)];
    }
    
    public static T GetRandom<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }   
    
    public static bool RemoveIfContained<T>(this List<T> list, T item)
    {
        if (!list.Contains(item)) return true;
        
        list.Remove(item);
        
        return false;
    }
    
    public static bool AddIfNotContained<T>(this List<T> list, T item)
    {
        if (list.Contains(item)) return true;
        
        list.Add(item);
        
        return false;
    }
}
