using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	public const string TargetActionName = "Target";
	public const string MainInteraction = "Main Interaction";
	public const string SecondaryInteraction = "Secondary Interaction";
	public const string MoveActionName = "Movement";

    public static event Action<Vector2> OnMouseScreenUpdate;
	public static event Action<Vector2> OnMoveUpdate;
    public static event Action<Vector3> OnMouseWorldUpdate;

	public static event Action OnMainInteraction;
	public static event Action OnSecondaryInteraction;

	[SerializeField] private InputActionAsset inputs;
	[SerializeField] private Camera camera;

	private void OnEnable()
	{
		inputs.FindAction(MainInteraction).performed += InvokeMainInteraction;
		inputs.FindAction(SecondaryInteraction).performed += InvokeSecondaryInteraction;
		
		
	}
	
	private void OnDisable()
	{
		inputs.FindAction(MainInteraction).performed -= InvokeMainInteraction;
		inputs.FindAction(SecondaryInteraction).performed -= InvokeSecondaryInteraction;
		
		
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
	
}
