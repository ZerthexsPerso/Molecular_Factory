using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	public static BuildingManager Instance;

	public GameObject CurrentSelectedBuilding;
	public GameObject BuildMenu;

	private void Awake()
	{
		if (Instance)
		{
			enabled = false;
			return;
		}

		Instance = this;
	}

	private void OnEnable()
	{
		InputManager.OnOpenBuildMenu += SwitchMenuState;
	}

	private void OnDisable()
	{
		InputManager.OnOpenBuildMenu -= SwitchMenuState;
	}

	private void SwitchMenuState()
	{
		BuildMenu.SetActive(!BuildMenu.activeSelf);

		GridInteraction.Instance.ApplyInteractionMode(
			(BuildMenu.activeSelf) ? InteractionMode.None : InteractionMode.Build
		);
	}

	public void Place(Vector2Int gridPos)
	{
		if (!CurrentSelectedBuilding)
		{
			Debug.Log("No building selected !");
			return;
		}
	
		if (GridManager.Instance.TrySet(gridPos, CurrentSelectedBuilding))
		{
			Debug.Log($"{CurrentSelectedBuilding.name} placed at [{gridPos.x}, {gridPos.y}]");
		}
		else
		{
			Debug.Log($"Failed to place {CurrentSelectedBuilding.name} at [{gridPos.x}, {gridPos.y}]");
		}
	}
}
