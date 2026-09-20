using Unity.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    const float NeighbourDetectionRange = 0.7f;

    public LayerMask connectionMask;

    public Pipe northConnection;
    public Pipe southConnection;
    public Pipe westConnection;
    public Pipe eastConnection;

    void Start()
    {
        var connextionContactFilter = ContactFilter2D.noFilter;
        northConnection = GetAdjacentPipe(NormalizedVector2.up, connextionContactFilter);
        southConnection = GetAdjacentPipe(NormalizedVector2.down, connextionContactFilter);
        westConnection = GetAdjacentPipe(NormalizedVector2.left, connextionContactFilter);
        eastConnection = GetAdjacentPipe(NormalizedVector2.right, connextionContactFilter);
    }


    Pipe GetAdjacentPipe(NormalizedVector2 direction, ContactFilter2D contactFilter)
    {
        var hitResult = Physics2D.Raycast(transform.position, direction, contactFilter, 1f, Allocator.Temp);

        if (hitResult.Length < 2) return null;

        var pipeComponent = hitResult[1].collider.GetComponent<Pipe>();
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

    void DrawGizmoConnection(Pipe connection)
    {
        Gizmos.DrawLine(transform.position, connection.transform.position);
    }
}
