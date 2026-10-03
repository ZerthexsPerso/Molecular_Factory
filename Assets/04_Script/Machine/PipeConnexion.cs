using UnityEngine;

public class PipeConnexion : MonoBehaviour
{
	[SerializeField] private Inventory linkedInventory;
	public Inventory Inventory => linkedInventory;
}
