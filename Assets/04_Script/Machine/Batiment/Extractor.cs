using UnityEngine;

public class Extractor : Machine
{
    void Update()
    {
        StartProduction(CheckRecipe());
    }

    protected override bool CheckRecipe()
    {
        if (inventory.TryGetRessourceAmount(activeRecipe.outputRessource.ressource) + activeRecipe.outputRessource.amountProduced < inventory.SlotSize || inventory.TryGetRessourceAmount(activeRecipe.outputRessource.ressource) == null)
        {
            return true;
        } else { return false; }
    }

    protected override void OutputProductMaker(Ressource ressource, Recipe recipe)
    {
        inventory.Add(recipe.outputRessource.amountProduced, ressource);
    }
}
