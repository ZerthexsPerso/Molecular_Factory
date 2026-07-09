using System;
using Unity.VisualScripting;
using UnityEngine;

public class MachineTemp : MonoBehaviour
{
    [Header ("Recipes")]
    public RecipeHolder recipeCatalogue;
    [ReadOnly] public Recipe activeRecipe;

    [Header("Input Items Stocked")]
    public ItemStock inputStock1;
    public ItemStock inputStock2;

    [Header("Output Items Stocked")]
    public ItemStock outputStock;

    [Header("Liked Input Pipes")]
    public TuyauTemp inputPipe1; 
    public TuyauTemp inputPipe2;

    [Header("Liked Output Pipes")]
    public TuyauTemp outputPipe1;
    public TuyauTemp outputPipe2;

    [Header("Stats")]
    [HideInInspector] public int pipeSpeed = 1;

    void Start()
    {
        TempsFunction();
        InvokeRepeating("PipeReceiver", 1f, 1f);
        InvokeRepeating("PipeSender", 1f, 1f);
    }

    void Update()
    {
        OutputMaker();
    }

    void TempsFunction()
    {
        if (recipeCatalogue.simpleLC[1]) activeRecipe = recipeCatalogue.simpleLC[1];
    }

    void OutputMaker()
    {
        string combinaison = "";
        if (inputStock1.amountInStock > 0 && inputStock2.amountInStock > 0)
        {
            combinaison += inputStock1.name + inputStock2.name;
        }
        if (CombinaisonChecker(combinaison))
        {
            outputStock.name = activeRecipe.output;
            outputStock.amountInStock += 1;
            inputStock1.amountInStock -= 1;
            inputStock2.amountInStock -= 1;
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

    void PipeReceiver()
    {
        if (inputPipe1) 
        {
            if (inputStock1.name == inputPipe1.itemInStock.name || inputStock1.name == "")
            {
                if (inputStock1.name == "") inputStock1.name = inputPipe1.itemInStock.name;
                inputStock1.amountInStock += pipeSpeed;
                inputPipe1.itemInStock.amountInStock -= pipeSpeed;
            }
        }

        if (inputPipe2) 
        {
            if (inputStock2.name == inputPipe2.itemInStock.name || inputStock2.name == "")
            {
                if (inputStock2.name == "") inputStock2.name = inputPipe2.itemInStock.name;
                inputStock2.amountInStock += pipeSpeed;
                inputPipe2.itemInStock.amountInStock -= pipeSpeed;
            }
        }
    }

    void PipeSender()
    {
        if (outputPipe1)
        {
            if (outputStock.name == outputPipe1.itemInStock.name || outputPipe1.itemInStock.name == "")
            {
                if (outputPipe1.itemInStock.name == "") outputPipe1.itemInStock.name = outputStock.name;
                outputStock.amountInStock -= pipeSpeed;
                outputPipe1.itemInStock.amountInStock += pipeSpeed;
            }
        }
    }
}
