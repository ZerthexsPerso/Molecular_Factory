using Unity.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    const float NeighbourDetectionRange = 0.7f;

    public LayerMask connectionMask;
    public Inventory content;

    public PipeConnexion northConnection;
    public PipeConnexion southConnection;
    public PipeConnexion westConnection;
    public PipeConnexion eastConnection;

    public PipeConnexion pipeConnector;

    private void Start()
    {
        var connextionContactFilter = ContactFilter2D.noFilter;
        northConnection = GetAdjacentPipe(NormalizedVector2.up, connextionContactFilter);
        southConnection = GetAdjacentPipe(NormalizedVector2.down, connextionContactFilter);
        westConnection = GetAdjacentPipe(NormalizedVector2.left, connextionContactFilter);
        eastConnection = GetAdjacentPipe(NormalizedVector2.right, connextionContactFilter);
    }

    private void Update()
    {
        BalanceContentWithNeighbours();
    }

    private PipeConnexion GetAdjacentPipe(NormalizedVector2 direction, ContactFilter2D contactFilter)
    {
        var hitResult = Physics2D.Raycast(transform.position, direction, contactFilter, 1f, Allocator.Temp);

        if (hitResult.Length < 2) return null;

        var pipeComponent = hitResult[1].collider.GetComponent<PipeConnexion>();
        Debug.Log(pipeComponent);

        if (!pipeComponent) return null;

        return pipeComponent;
    }

    private void BalanceContentWithNeighbours()
    {
        float totalContent = content.GetSlotAtIndex(0).Amount;
        float neighbourCount = 0;
        Ressource currentRessource = content.GetSlotAtIndex(0).RessourceType;

        float? northAmount = northConnection?.Inventory.TryGetRessourceAmount(currentRessource);
        if (northAmount.HasValue) 
        {
            totalContent += northAmount.Value;
            neighbourCount++;
        }

        float? southAmount = southConnection?.Inventory.TryGetRessourceAmount(currentRessource);
        if (southAmount.HasValue) 
        {
            totalContent += southAmount.Value;
            neighbourCount++;
        }

        float? westAmount = westConnection?.Inventory.TryGetRessourceAmount(currentRessource);
        if (westAmount.HasValue) 
        {
            totalContent += westAmount.Value;
            neighbourCount++;
        }

        float? eastAmount = eastConnection?.Inventory.TryGetRessourceAmount(currentRessource);
        if (eastAmount.HasValue) 
        {
            totalContent += eastAmount.Value;
            neighbourCount++;
        }

        float balancedAmount = totalContent / (neighbourCount + 1);

        content.GetSlotAtIndex(0).Empty();
        content.GetSlotAtIndex(0).TryAdd(balancedAmount);

        if (northConnection.Inventory.TryGetRessourceAmount(currentRessource).HasValue)
        {
            northConnection.Inventory.GetSlotAtIndex(0).Empty();
            northConnection.Inventory.GetSlotAtIndex(0).TryAdd(balancedAmount);
        }

        if (southConnection.Inventory.TryGetRessourceAmount(currentRessource).HasValue)
        {
            southConnection.Inventory.GetSlotAtIndex(0).Empty();
            southConnection.Inventory.GetSlotAtIndex(0).TryAdd(balancedAmount);
        }

        if (westConnection.Inventory.TryGetRessourceAmount(currentRessource).HasValue)
        {
            westConnection.Inventory.GetSlotAtIndex(0).Empty();
            westConnection.Inventory.GetSlotAtIndex(0).TryAdd(balancedAmount);
        }

        if (eastConnection.Inventory.TryGetRessourceAmount(currentRessource).HasValue)
        {
            eastConnection.Inventory.GetSlotAtIndex(0).Empty();
            eastConnection.Inventory.GetSlotAtIndex(0).TryAdd(balancedAmount);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.15f);

        if (northConnection) DrawGizmoConnection(northConnection);
        if (southConnection) DrawGizmoConnection(southConnection);
        if (westConnection) DrawGizmoConnection(westConnection);
        if (eastConnection) DrawGizmoConnection(eastConnection);        
    }

    private void DrawGizmoConnection(PipeConnexion connection)
    {
        Gizmos.DrawLine(transform.position, connection.transform.position);
    }
}
