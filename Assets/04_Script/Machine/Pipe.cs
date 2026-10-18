using Unity.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    const float NeighbourDetectionRange = 0.7f;

    public LayerMask connectionMask;
    public Inventory content;

    [SerializeField] private PipeConnexion[] pipeConnexions = new PipeConnexion[4];

    public PipeConnexion pipeConnector;

    private void Start()
    {
        var connextionContactFilter = ContactFilter2D.noFilter;
        pipeConnexions[0] = GetAdjacentPipe(NormalizedVector2.up, connextionContactFilter);
        pipeConnexions[1] = GetAdjacentPipe(NormalizedVector2.down, connextionContactFilter);
        pipeConnexions[2] = GetAdjacentPipe(NormalizedVector2.left, connextionContactFilter);
        pipeConnexions[3] = GetAdjacentPipe(NormalizedVector2.right, connextionContactFilter);

        Connect();
    }

    private void Update()
    {
        // BalanceContentWithNeighbours();
    }

    private void Connect()
    {
        foreach (var connexion in pipeConnexions)
        {
            if (!connexion) continue;
            connexion.connexions.Add(pipeConnector);
        }
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

        foreach (var connexion in pipeConnexions)
        {
            float? connexionRessourceAmount = connexion?.Inventory.TryGetRessourceAmount(currentRessource);
            if (!connexionRessourceAmount.HasValue) continue;

            totalContent += connexionRessourceAmount.Value;
            neighbourCount++;
        }

        float balancedAmount = totalContent / (neighbourCount + 1);

        content.GetSlotAtIndex(0).Empty();
        content.GetSlotAtIndex(0).TryAdd(balancedAmount);

        foreach (var connexion in pipeConnexions)
        {
            if (!connexion.Inventory.TryGetRessourceAmount(currentRessource).HasValue) continue;

            connexion.Inventory.GetSlotAtIndex(0).Empty();
            connexion.Inventory.GetSlotAtIndex(0).TryAdd(balancedAmount);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.15f);

        foreach (var connexion in pipeConnexions)
        {
            if (connexion) DrawGizmoConnection(connexion);
        }
    }

    private void DrawGizmoConnection(PipeConnexion connection)
    {
        // Gizmos.DrawLine(transform.position, connection.transform.position);
    }
}
