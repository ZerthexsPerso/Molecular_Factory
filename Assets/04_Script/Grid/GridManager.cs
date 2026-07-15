using System;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static event Action<Vector2Int> OnCellHovered;

    public static GridManager Instance;
    
    [SerializeField] private Grid grid;
    [HideInInspector] public Vector2Int hoveredCell;

    public GameObject dummy;
    public GridContent content = new GridContent();

    private void Awake()
    {
        if (Instance)
        {
            enabled = false;
            return;
        }

        Instance = this;
    }

    private void OnEnable()
    {
        InputManager.OnMouseWorldUpdate += FindHoveredCell;
    }

    private void OnDisable()
    {
        InputManager.OnMouseWorldUpdate -= FindHoveredCell;
    }
    
    private void FindHoveredCell(Vector3 mousePosition)
    {
        hoveredCell = (Vector2Int)grid.LocalToCell(mousePosition);
        OnCellHovered.Invoke(hoveredCell);
    }

    public Vector3 GetCoordinates(Vector2Int gridPos)
    {
        return grid.GetCellCenterLocal((Vector3Int)gridPos);
    }



    public bool TrySet(Vector2Int pos, GameObject element)
    {
        if (content.Get(pos))
        {
            return false;
        }

        Set(pos, element);

        return true;
    }

    public void Set(Vector2Int pos, GameObject element)
    {
        GameObject elementInstance = Instantiate(element, GetCoordinates(pos), Quaternion.identity);
        content.content[pos.x, pos.y] = elementInstance;
    }
    
}
