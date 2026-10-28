using System;
using UnityEngine;

[Serializable]
public class RessourceSlot
{
	[SerializeField] private Ressource ressourceType;
	public Ressource RessourceType => ressourceType;
	[SerializeField] private float amount;
	public float Amount => amount;
	[SerializeField] private float capacity = 64;

	public RessourceSlot(Ressource ressourceType, float amount, float capacity)
	{
		this.ressourceType = ressourceType;
		this.amount = amount;
		this.capacity = capacity;
	}

	public bool TryAdd(float addedAmount)
	{
		float newAmount = amount + addedAmount;

		if (newAmount > capacity)
		{
			return false;
		}
		else
		{
			amount = newAmount;
			return true;
		}
	}

	public bool TryRemove(float removedAmount)
	{
		float newAmount = amount - removedAmount;

		if (newAmount < 0)
		{
			return false;
		}
		else
		{
			amount = newAmount;
			return true;
		}
	}

	public float AddAndReturnExcess(float addedAmount)
	{
		var newAmount = amount + addedAmount;
		amount = Mathf.Min(capacity, newAmount);
		var excess = newAmount - capacity;

		return excess > 0f ? excess : 0f;
	}

	public void Empty()
	{
		amount = 0;
	}
}

