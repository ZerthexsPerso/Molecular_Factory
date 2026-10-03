using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private List<RessourceSlot> content = new List<RessourceSlot>();

	public float? TryGetRessourceAmount(Ressource searchedRessource)
	{
		foreach (RessourceSlot slot in content)
		{
			if (slot.RessourceType == searchedRessource)
			{
				return slot.Amount;
			}
		}

		return null;
	}
}
