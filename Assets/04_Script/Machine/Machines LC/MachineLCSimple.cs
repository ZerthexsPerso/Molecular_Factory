using UnityEngine;

public class MachineLCSimple : MachineLC
{
    [Header("Input Items Stocked")]
    public ItemStock inputStock1;
    public ItemStock inputStock2;

    [Header("Output Items Stocked")]
    public ItemStock outputStock;

    [Header("Linked Input Pipes")]
    public TuyauTemp inputPipe1;
    public TuyauTemp inputPipe2;

    [Header("Linked Output Pipes")]
    public TuyauTemp outputPipe;

    public override void OutputMaker()
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
