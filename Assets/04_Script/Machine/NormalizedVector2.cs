using UnityEngine;

public struct NormalizedVector2
{
    public static NormalizedVector2 up => new NormalizedVector2(Vector2.up);
    public static NormalizedVector2 down => new NormalizedVector2(Vector2.down);
    public static NormalizedVector2 left => new NormalizedVector2(Vector2.left);
    public static NormalizedVector2 right => new NormalizedVector2(Vector2.right);    

    Vector2 value;

    NormalizedVector2(Vector2 value)
    {
        this.value = value;
    }

    public static NormalizedVector2? From(Vector2 value)
    {
        if (value.sqrMagnitude == 1f)
            return new NormalizedVector2(value.normalized);
        else
            return null;
    }

    public static implicit operator Vector2(NormalizedVector2 unitVector) => unitVector.value;
}

