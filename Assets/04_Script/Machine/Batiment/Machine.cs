using System;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public Recipe activeRecipe;
    public Inventory inventory;
    protected float time;

    protected virtual bool CheckRecipe()
    {
        throw new NotImplementedException();
    }
    protected virtual void StartProduction(bool isProductionActive)
    {
        if (isProductionActive)
        {
            time += Time.deltaTime;
            while (time >= activeRecipe.productionTime)
            {
                OutputProductMaker(activeRecipe.outputRessource.ressource, activeRecipe);
                time -= activeRecipe.productionTime;
            }
        }
    }

    protected virtual void OutputProductMaker(Ressource ressource, Recipe recipe)
    {
        throw new NotImplementedException();
    }
}
