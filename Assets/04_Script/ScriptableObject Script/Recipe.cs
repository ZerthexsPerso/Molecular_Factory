using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct Ingredient
{
    public Ressource ressource;
    public float amountNeeded;
}

[System.Serializable]
public struct OutputRessource
{
    public Ressource ressource;
    public float amountProduced;
}

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public enum RecipeType
    {
        Extractor,
        Fusion,
        Debug
    };

    [SerializeField] public RecipeType type;

    [SerializeField] public Ingredient[] inputRessources;
    [SerializeField] public OutputRessource outputRessource;
    public float productionTime = 1f;

    public List<string> warningDetector()
    {
        List<string> warnings = new List<string>();
        switch (type)
        {
            case RecipeType.Fusion:
                if (inputRessources.Any(item => item.ressource == null) || inputRessources.Length == 0) warnings.Add("Input items are missing");
                if (inputRessources.Any(item => item.amountNeeded <= 0)) warnings.Add("Input items amount are not valid");
                if (!outputRessource.ressource) warnings.Add("Output item is missing");
                if (outputRessource.amountProduced <= 0) warnings.Add("Output item ammount is missing");
                break;
        }
        return warnings;
    } 
}