using System.Collections.Generic;
using UnityEngine;

public class PipeConnexion : MonoBehaviour
{
	[SerializeField] private BalanceMode balanceMode;
	public BalanceMode BalanceMode => balanceMode;

	[SerializeField] private Inventory linkedInventory;
	public Inventory Inventory => linkedInventory;

	public List<PipeConnexion> connexions = new List<PipeConnexion>();

	[HideInInspector] public bool markedAsConnected;
}
