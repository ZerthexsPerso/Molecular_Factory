using System.Collections.Generic;
using UnityEngine;

public class PipeBalancingSystem : MonoBehaviour
{
	private List<List<PipeConnexion>> networks = new List<List<PipeConnexion>>();

	private void Update()
    {
        var allPipes = FindObjectsByType<PipeConnexion>();
		ResetConnexions(allPipes);

		networks.Clear();
		
        LinkPipes(allPipes, networks);

		foreach (var network in networks)
		{
			BalanceNetwork(network);
		}
    }

	private void OnDrawGizmos()
	{
		DrawNetworks(networks);
	}

	private void ResetConnexions(PipeConnexion[] allPipes)
	{
		foreach (var connexion in allPipes)
		{
			connexion.markedAsConnected = false;
		}
	}

    private void LinkPipes(PipeConnexion[] allPipes, List<List<PipeConnexion>> networks)
    {
        for (int i = 0; i < allPipes.Length; i++)
        {
			var pipe = allPipes[i];
            if (!pipe || pipe.markedAsConnected) continue;

            var currenNetwork = new List<PipeConnexion>();
            var leaves = new Stack<PipeConnexion>();
			pipe.markedAsConnected = true;
			currenNetwork.Add(pipe);
			leaves.Push(pipe);

            while (leaves.Count != 0)
            {
                Connect(leaves.Pop(), currenNetwork, leaves);
            }

			networks.Add(currenNetwork);
        }
    }

    private static void Connect(PipeConnexion pipe, List<PipeConnexion> network, Stack<PipeConnexion> leaves)
    {
        foreach (var connexion in pipe.connexions)
        {
			if (!connexion || connexion.markedAsConnected) continue;

			connexion.markedAsConnected = true;
			network.Add(connexion);
            leaves.Push(connexion);
        }
    }

	private void DrawNetworks(List<List<PipeConnexion>> networks)
	{
		foreach (var netwrok in networks)
		{
			var randomColor = Random.ColorHSV();
			Gizmos.color = randomColor;

			foreach (var pipe in netwrok)
			{
				Gizmos.DrawSphere(pipe.transform.position, 0.5f);
			}
		}
	}

	private static void BalanceNetwork(List<PipeConnexion> network)
	{
		float totalAmount = 0f;
	
		foreach (var pipe in network)
		{
			totalAmount += pipe.Inventory.GetSlotAtIndex(0).Amount;
		}

		float balancedAmount = totalAmount / network.Count;

		foreach (var pipe in network)
		{
			pipe.Inventory.GetSlotAtIndex(0).Empty();
			pipe.Inventory.GetSlotAtIndex(0).TryAdd(balancedAmount);
		}
	}

	private static float FillAllIn(List<PipeConnexion> network, float totalAmount)
	{
		// Peut être changer ça un jour jsp
		foreach (var pipe in network)
		{
			if (pipe.BalanceMode == BalanceMode.AllIn)
			{
				
			}
		}

		return 0f;
	}
}
