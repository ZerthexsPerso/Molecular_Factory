using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MachineLC : MonoBehaviour
{
    [Header ("Recipes")]
    public RecipeHolder recipeCatalogue;
    [ReadOnly] public Recipe activeRecipe;

    [Header("Stats")]
    [HideInInspector] public int pipeSpeed = 1;

    public virtual void Start()
    {
        TempsFunction();
        InvokeRepeating("PipeReceiver", 1f, 1f);
        InvokeRepeating("PipeSender", 1f, 1f);
    }

    public virtual void Update()
    {
        OutputMaker();
    }

    public virtual void TempsFunction()
    {
        if (recipeCatalogue.simpleLC[1]) activeRecipe = recipeCatalogue.simpleLC[1];
    }

    public abstract void OutputMaker();
    

    public virtual bool CombinaisonChecker(string combinaison)
    {
        if (activeRecipe.output == combinaison) return true;
        char[] chars = combinaison.ToCharArray();
        Array.Reverse(chars);
        string reverseOutput = new string(chars);
        if (activeRecipe.output == reverseOutput) return true;
        return false;
    }

    public abstract void PipeReceiver();

    public abstract void PipeSender();
}
