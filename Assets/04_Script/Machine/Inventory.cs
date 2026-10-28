using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] private int slotSize;

	[SerializeField] private List<RessourceSlot> content = new List<RessourceSlot>();

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

	public void Add(float amount, Ressource type)
	{
		if (InteractWithSlot(type, slot => {slot.TryAdd(amount); return 0f; }) != null) return;

		content.Add(new RessourceSlot(type, amount, slotSize));
	}

    public void Remove(float amount, Ressource type)
    {
		InteractWithSlot(type, slot => { slot.TryRemove(amount); return 0f; });
    }

	public float? AddAndReturnExcess(float amount, Ressource type)
	{
		return InteractWithSlot(type, slot => { slot.AddAndReturnExcess(amount); return 0f; });
	}

	private float? InteractWithSlot(Ressource type, Func<RessourceSlot, float> interact)
	{
		foreach (RessourceSlot slot in content)
		{
			if (slot.RessourceType == type)
			{
				return interact(slot);
			}
		}

		return null;
	}

    public RessourceSlot GetSlotAtIndex(int index)
	{
		return content[index];
	}
}
