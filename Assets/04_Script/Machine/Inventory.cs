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
		foreach (RessourceSlot slot in content)
		{
			if (slot.RessourceType == type)
			{
				slot.TryAdd(amount);
				return;
			}
		}

		content.Add(new RessourceSlot(type, amount, slotSize));
	}

    public void Remove(float amount, Ressource type)
    {
        foreach (RessourceSlot slot in content)
        {
            if (slot.RessourceType == type)
            {
                slot.TryRemove(amount);
                return;
            }
        }
    }

    public RessourceSlot GetSlotAtIndex(int index)
	{
		return content[index];
	}
}
