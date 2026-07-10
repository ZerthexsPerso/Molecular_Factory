using System;
using UnityEngine;

public struct InteractionMode
{
	public Action<Vector2Int> MainAction;
	public Action<Vector2Int> SecondaryAction;

	public static readonly InteractionMode Debug = new InteractionMode()
	{
		MainAction = new Action<Vector2Int>(pos =>
		{
			if (GridManager.Instance.content.TrySet(pos, GridManager.Instance.dummy))
			{
				UnityEngine.Debug.Log("Placement réussi !");
			}
			else
			{
				UnityEngine.Debug.Log("Placemen raté ...");
			}
		}),
		SecondaryAction = new Action<Vector2Int>(pos =>
		{
			
		})
	};
}

