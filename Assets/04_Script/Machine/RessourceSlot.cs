public class RessourceSlot
{
	Ressource ressourceType;
	int amount;
	int capacity;

	public bool TryAdd(int addedAmount)
	{
		int newAmount = amount + addedAmount;

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

	public bool TryRemove(int removedAmount)
	{
		int newAmount = amount - removedAmount;

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
}

