using UnityEngine;

public class DummyMachine : MonoBehaviour
{
    public Inventory inventory;
    // public RessourceSlot slot;

    Ressource ressourceInSlot;
    public Ressource ressourceProduced;

    float producingInterval = 1;
    float time;

    void Start()
    {
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        while (time >= producingInterval)
        {
            RessourceProductor(ressourceProduced);
            time -= producingInterval;
        }
    }

    void RessourceProductor(Ressource ressource)
    {
        if (inventory.GetSlotAtIndex(0).Amount == 0)
        {
            ressourceInSlot = ressource;
        }
        if (ressourceInSlot == ressource)
        {
            inventory.GetSlotAtIndex(0).TryAdd(1);
        }
    }

}
