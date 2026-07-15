using System;
using UnityEngine;

public struct InteractionMode
{
	public Action<Vector2Int> MainAction;
	public Action<Vector2Int> SecondaryAction;

	public static readonly InteractionMode None = new InteractionMode()
	{
		MainAction = null,
		SecondaryAction = null
	};

	public static readonly InteractionMode Build = new InteractionMode()
	{
		MainAction = new Action<Vector2Int>(BuildingManager.Instance.Place),
		SecondaryAction = null
	};
}

