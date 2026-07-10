using UnityEngine;

public class GridHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlightOverlay;

    private void OnEnable()
    {
        GridManager.OnCellHovered += SetOverlay;
    }

    private void OnDisable()
    {
        GridManager.OnCellHovered -= SetOverlay;
    }

    private void SetOverlay(Vector2Int gridPos)
    {
       highlightOverlay.transform.position = GridManager.Instance.GetCoordinates(gridPos); 
    }
}

