using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	public const string TargetActionName = "Target";
	public const string MainInteractionActionName = "Main Interaction";
	public const string SecondaryInteractionActionName = "Secondary Interaction";
	public const string MoveActionName = "Movement";
	public const string OpenBuildMenuActionName = "Open Build Menu";

    public static event Action<Vector2> OnMouseScreenUpdate;
	public static event Action<Vector2> OnMoveUpdate;
    public static event Action<Vector3> OnMouseWorldUpdate;

	public static event Action OnMainInteraction;
	public static event Action OnSecondaryInteraction;
	public static event Action OnOpenBuildMenu;

	[SerializeField] private InputActionAsset inputs;
	[SerializeField] private Camera camera;

	private void OnEnable()
	{
		inputs.FindAction(MainInteractionActionName).performed += InvokeMainInteraction;
		inputs.FindAction(SecondaryInteractionActionName).performed += InvokeSecondaryInteraction;
		inputs.FindAction(OpenBuildMenuActionName).performed += InvokeOpenBuildMenu;
		
	}
	
	private void OnDisable()
	{
		inputs.FindAction(MainInteractionActionName).performed -= InvokeMainInteraction;
		inputs.FindAction(SecondaryInteractionActionName).performed -= InvokeSecondaryInteraction;
		inputs.FindAction(OpenBuildMenuActionName).performed -= InvokeOpenBuildMenu;
		
	}
	
	
	private void Update()
	{
		Vector2 mousePosition = inputs.FindAction(TargetActionName).ReadValue<Vector2>();
		OnMouseScreenUpdate?.Invoke(mousePosition);

		Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(mousePosition);
		OnMouseWorldUpdate?.Invoke(mouseWorldPosition);

		Vector2 movement = inputs.FindAction(MoveActionName).ReadValue<Vector2>();
        OnMoveUpdate?.Invoke(movement);

    }

	private void InvokeMainInteraction(InputAction.CallbackContext context)
	{
		OnMainInteraction?.Invoke();
	}
	
	private void InvokeSecondaryInteraction(InputAction.CallbackContext context)
	{
		OnSecondaryInteraction?.Invoke();
	}

	private void InvokeOpenBuildMenu(InputAction.CallbackContext context)
	{
		OnOpenBuildMenu?.Invoke();
	}
	
}
