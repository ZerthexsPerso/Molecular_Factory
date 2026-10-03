using Unity.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    const float NeighbourDetectionRange = 0.7f;

    public LayerMask connectionMask;
    public RessourceSlot content;

    public PipeConnexion northConnection;
    public PipeConnexion southConnection;
    public PipeConnexion westConnection;
    public PipeConnexion eastConnection;

    [HideInInspector] public PipeConnexion pipeConnector;

    private void Awake()
    {
        pipeConnector = gameObject.AddComponent<PipeConnexion>();
    }

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
        int totalContent = content.Amount;

        // if (northConnection) totalContent += northConnection.Inventory.TryGetComponent
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
