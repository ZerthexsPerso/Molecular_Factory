using UnityEngine;

public class GridContent
{
    public const int Size = 50;
    
    public GameObject[,] content = new GameObject[Size, Size];

    public GameObject Get(Vector2Int pos)
    {
        return content[pos.x, pos.y];
    }
}

