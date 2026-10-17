using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public enum RecipeType
    {
        Fusion,
        Debug
    };

    [SerializeField] public RecipeType type;

    [SerializeField] public Ressource[] inputRessources;
    [SerializeField] public Ressource outputRessource;
    public float productionTime = 1;

    public List<string> warningDetector()
    {
        List<string> warnings = new List<string>();
        switch (type)
        {
            case RecipeType.Fusion:
                if (inputRessources.Any(item => item == null) || inputRessources.Length == 0) warnings.Add("Input items are missing");
                if (!outputRessource) warnings.Add("Output item is missing");
                break;
        }
        return warnings;
    } 
}