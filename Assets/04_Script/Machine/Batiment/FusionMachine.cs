using UnityEngine;

public class FusionMachine : MonoBehaviour
{
    public Recipe activeRecipe;
    public Inventory inventory;

    float time;


    void Start()
    {
        
    }

    void Update()
    {
        StartProduction(CheckRecipe());
    }

    bool CheckRecipe()
    {
        foreach (var ingredient in activeRecipe.inputRessources)
        {
            if (inventory.TryGetRessourceAmount(ingredient.ressource) != null && inventory.TryGetRessourceAmount(ingredient.ressource) >= ingredient.amountNeeded && inventory.TryGetRessourceAmount(activeRecipe.outputRessource.ressource) + activeRecipe.outputRessource.amountProduced < inventory.SlotSize)
            {
                continue;
            }
            else return false;
        }
        return true;
    }

    void StartProduction(bool isProductionActive)
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

    void OutputProductMaker(Ressource ressource, Recipe recipe)
    {
        foreach(var recipeRessource in recipe.inputRessources)
        {
            inventory.Remove(recipeRessource.amountNeeded, recipeRessource.ressource);
        }
        inventory.Add(recipe.outputRessource.amountProduced, ressource);
    }
}
