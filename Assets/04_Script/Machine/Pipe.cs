using Unity.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    const float NeighbourDetectionRange = 0.7f;

    public LayerMask connectionMask;

    public PipeConnexion northConnection;
    public PipeConnexion southConnection;
    public PipeConnexion westConnection;
    public PipeConnexion eastConnection;

    [HideInInspector] public PipeConnexion pipeConnector;

    private void Awake()
    {
        pipeConnector = gameObject.AddComponent<PipeConnexion>();
    }

    void Start()
    {
        var connextionContactFilter = ContactFilter2D.noFilter;
        northConnection = GetAdjacentPipe(NormalizedVector2.up, connextionContactFilter);
        southConnection = GetAdjacentPipe(NormalizedVector2.down, connextionContactFilter);
        westConnection = GetAdjacentPipe(NormalizedVector2.left, connextionContactFilter);
        eastConnection = GetAdjacentPipe(NormalizedVector2.right, connextionContactFilter);
    }

    PipeConnexion GetAdjacentPipe(NormalizedVector2 direction, ContactFilter2D contactFilter)
    {
        var hitResult = Physics2D.Raycast(transform.position, direction, contactFilter, 1f, Allocator.Temp);

        if (hitResult.Length < 2) return null;

        var pipeComponent = hitResult[1].collider.GetComponent<PipeConnexion>();
        Debug.Log(pipeComponent);

        if (!pipeComponent) return null;

        return pipeComponent;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.15f);

        if (northConnection) DrawGizmoConnection(northConnection);
        if (southConnection) DrawGizmoConnection(southConnection);
        if (westConnection) DrawGizmoConnection(westConnection);
        if (eastConnection) DrawGizmoConnection(eastConnection);        
    }

    void DrawGizmoConnection(PipeConnexion connection)
    {
        Gizmos.DrawLine(transform.position, connection.transform.position);
    }
}
