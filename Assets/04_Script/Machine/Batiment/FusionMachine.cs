using UnityEngine;

public class FusionMachine : Machine
{
    void Start()
    {
        
    }

    void Update()
    {
        StartProduction(CheckRecipe());
    }

    protected override bool CheckRecipe()
    {
        foreach (var ingredient in activeRecipe.inputRessources)
        {
            if ((inventory.TryGetRessourceAmount(ingredient.ressource) != null && inventory.TryGetRessourceAmount(ingredient.ressource) >= ingredient.amountNeeded && inventory.TryGetRessourceAmount(activeRecipe.outputRessource.ressource) + activeRecipe.outputRessource.amountProduced <= inventory.SlotSize) || inventory.TryGetRessourceAmount(activeRecipe.outputRessource.ressource) == null)
            {
                continue;
            }
            else return false;
        }
        return true;
    }

    protected override void OutputProductMaker(Ressource ressource, Recipe recipe)
    {
        foreach(var recipeRessource in recipe.inputRessources)
        {
            inventory.Remove(recipeRessource.amountNeeded, recipeRessource.ressource);
        }
        inventory.Add(recipe.outputRessource.amountProduced, ressource);
    }
}
