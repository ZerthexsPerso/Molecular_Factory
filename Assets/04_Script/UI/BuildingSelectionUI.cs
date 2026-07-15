using UnityEngine;
using UnityEngine.UIElements;

public class BuildingSelectionUI : MonoBehaviour
{
    [SerializeField] private VisualElementReference<Button> simpleMachineButton;
    [SerializeField] private GameObject simpleMachinePrefab; 

    private void Start()
    {
        simpleMachineButton.RegisterReferenceResolvedCallback(button => ChangeSelectedBuilding(simpleMachinePrefab));
    }

    private void ChangeSelectedBuilding(GameObject selectedBuilding)
    {
        BuildingManager.Instance.CurrentSelectedBuilding = selectedBuilding;
    }
}
