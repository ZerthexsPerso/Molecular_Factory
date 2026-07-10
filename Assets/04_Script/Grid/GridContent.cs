using UnityEngine;

public class GridContent
{
    public const int Size = 50;
    
    private GameObject[,] content = new GameObject[Size, Size];

    public GameObject Get(Vector2Int pos)
    {
        return content[pos.x, pos.y];
    }

    public bool TrySet(Vector2Int pos, GameObject element)
    {
        if (Get(pos))
        {
            return false;
        }

        Set(pos, element);

        return true;
    }

    public void Set(Vector2Int pos, GameObject element)
    {
        content[pos.x, pos.y] = element;
    }
}

