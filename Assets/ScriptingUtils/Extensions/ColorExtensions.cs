﻿using UnityEngine;

public static class ColorExtensions
{
    public static Color SetAlpha(this Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }
    public static Color GetWhiteAlpha(this Color color,float alpha)
    {
        return new Color(color.r,color.g,color.b, alpha);
    }
}
