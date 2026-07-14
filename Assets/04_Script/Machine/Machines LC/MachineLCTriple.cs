using UnityEngine;

public class MachineLCTriple : MachineLC
{
    [Header("Input Items Stocked")]
    public ItemStock inputStock1;
    public ItemStock inputStock2;
    public ItemStock inputStock3;
    public ItemStock inputStock4;

    [Header("Output Items Stocked")]
    public ItemStock outputStock;

    [Header("Linked Input Pipes")]
    public TuyauTemp inputPipe1;
    public TuyauTemp inputPipe2;
    public TuyauTemp inputPipe3;
    public TuyauTemp inputPipe4;

    [Header("Linked Output Pipes")]
    public TuyauTemp outputPipe;


    public override void TempsFunction()
    {
        if (recipeCatalogue.tripleLC[1]) activeRecipe = recipeCatalogue.tripleLC[1];
    }

    public override void OutputMaker()
    {
        string combinaison = "";
        if (inputStock1.amountInStock > 0 && inputStock2.amountInStock > 0 && inputStock3.amountInStock > 0 && inputStock4.amountInStock > 0)
        {
            combinaison += inputStock1.name + inputStock2.name + inputStock3 + inputStock4;
        }
        if (CombinaisonChecker(combinaison))
        {
            outputStock.name = activeRecipe.output;
            outputStock.amountInStock += 1;
            inputStock1.amountInStock -= 1;
            inputStock2.amountInStock -= 1;
            inputStock3.amountInStock -= 1;
            inputStock4.amountInStock -= 1;
        }
    }

    public override void PipeReceiver()
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

        if (inputPipe3)
        {
            if (inputStock3.name == inputPipe3.itemInStock.name || inputStock3.name == "")
            {
                if (inputStock3.name == "") inputStock3.name = inputPipe3.itemInStock.name;
                inputStock3.amountInStock += pipeSpeed;
                inputPipe3.itemInStock.amountInStock -= pipeSpeed;
            }
        }

        if (inputPipe4)
        {
            if (inputStock4.name == inputPipe4.itemInStock.name || inputStock4.name == "")
            {
                if (inputStock4.name == "") inputStock4.name = inputPipe4.itemInStock.name;
                inputStock4.amountInStock += pipeSpeed;
                inputPipe4.itemInStock.amountInStock -= pipeSpeed;
            }
        }
    }
    public override void PipeSender()
    {
        if (outputPipe)
        {
            if (outputStock.name == outputPipe.itemInStock.name || outputPipe.itemInStock.name == "")
            {
                if (outputPipe.itemInStock.name == "") outputPipe.itemInStock.name = outputStock.name;
                outputStock.amountInStock -= pipeSpeed;
                outputPipe.itemInStock.amountInStock += pipeSpeed;
            }
        }
    }
}
