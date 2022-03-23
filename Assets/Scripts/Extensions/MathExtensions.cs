public static class MathExtensions
{
    public static float DefaultIfZero(this float f, float z)
    {
        return f > 0 ? f : z;
    }

}
