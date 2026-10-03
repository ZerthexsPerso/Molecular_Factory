using System;
using System.Collections;
using UnityEngine;

public class DummyMachine : MonoBehaviour
{
    RessourceSlot slot;
    Ressource ressourceInSlot;
    public Ressource ressourceProducted;
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
            RessourceProductor(ressourceProducted);
            time -= producingInterval;
        }
    }

    void RessourceProductor(Ressource ressource)
    {
        if (slot.Amount == 0)
        {
            ressourceInSlot = ressource;
        }
        if (ressourceInSlot == ressource)
        {
            slot.TryAdd(1);
        }
    }

}
