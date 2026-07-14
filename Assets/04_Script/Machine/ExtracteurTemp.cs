using UnityEngine;

public class ExtracteurTemp : MonoBehaviour
{
    [Header("Input Items Stocked")]
    public ItemStock inputStock;

    [Header("Linked Output Pipes")]
    public TuyauTemp outputPipe;

    [Header("Stats")]
    [HideInInspector] public int pipeSpeed = 1;

    private void Start()
    {
        InvokeRepeating("RessourceCollector", 1f, 1f);
        InvokeRepeating("PipeSender", 1f, 1f);

    }

    void RessourceCollector()
    {
        inputStock.amountInStock += 1;
    }

    void PipeSender()
    {
        if (outputPipe)
        {
            if (inputStock.name == outputPipe.itemInStock.name || outputPipe.itemInStock.name == "")
            {
                if (outputPipe.itemInStock.name == "") outputPipe.itemInStock.name = inputStock.name;
                inputStock.amountInStock -= pipeSpeed;
                outputPipe.itemInStock.amountInStock += pipeSpeed;
            }
        }
    }
}
