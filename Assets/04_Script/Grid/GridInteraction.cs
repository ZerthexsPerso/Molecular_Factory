using System;
using UnityEngine;

public class GridInteraction : MonoBehaviour
{
	public Action<Vector2Int> MainAction;
	public Action<Vector2Int> SecondaryAction;

	private void OnEnable()
	{
		InputManager.OnMainInteraction += InvokeMainInteraction;
		InputManager.OnSecondaryInteraction += InvokeSecondaryAction;
	}
	
	private void OnDisable()
	{
		InputManager.OnMainInteraction -= InvokeMainInteraction;
		InputManager.OnSecondaryInteraction -= InvokeSecondaryAction;
	}

	private void Start()
	{
		ApplyInteractionMode(InteractionMode.Debug);
	}

	private void ApplyInteractionMode(InteractionMode newMode)
	{
		MainAction = newMode.MainAction;
		SecondaryAction = newMode.SecondaryAction;
	}

	private void InvokeMainInteraction()
	{
		MainAction.Invoke(GridManager.Instance.hoveredCell);
	}

	private void InvokeSecondaryAction()
	{
		MainAction.Invoke(GridManager.Instance.hoveredCell);
	}
}
