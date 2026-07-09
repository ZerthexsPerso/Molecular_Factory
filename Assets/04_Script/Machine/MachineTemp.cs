using System;
using UnityEngine;

public class MachineTemp : MonoBehaviour
{
    [Header ("Recipes")]
    public RecipeHolder recipeCatalogue;
    [ReadOnly] public Recipe activeRecipe;

    [Header("Atoms Stocked")]
    public AtomStock atomStock1;
    public AtomStock atomStock2;
    private AtomStock[] atomStocks;

    public AtomStock outputStock;

    void Start()
    {
        SetupStocks();
        TempsFunction();
    }

    void Update()
    {
        OutputMaker();
    }

    void SetupStocks()
    {
        atomStocks = new AtomStock[] {atomStock1, atomStock2};
    }

    void TempsFunction()
    {
        if (recipeCatalogue.simpleLC[1]) activeRecipe = recipeCatalogue.simpleLC[1];
    }

    void OutputMaker()
    {
        string combinaison = "";
        if (atomStock1.amountInStock > 0 && atomStock2.amountInStock > 0)
        {
            combinaison += atomStock1.name + atomStock2.name;
        }
        if (CombinaisonChecker(combinaison))
        {
            outputStock.name = activeRecipe.output;
            outputStock.amountInStock += 1;
            atomStock1.amountInStock -= 1;
            atomStock2.amountInStock -= 1;
        }
    }

    bool CombinaisonChecker(string combinaison)
    {
        if (activeRecipe.output == combinaison) return true;
        char[] chars = combinaison.ToCharArray();
        Array.Reverse(chars);
        string reverseOutput = new string(chars);
        if (activeRecipe.output == reverseOutput) return true;
        return false;
    }
}
