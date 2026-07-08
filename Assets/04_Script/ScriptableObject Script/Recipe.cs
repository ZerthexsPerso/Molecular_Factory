using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable Objects/Recipe")]

public class Recipe : ScriptableObject
{
    public enum RecipeType
    {
        DoubleLiaisonChimique,
        TripleLiaisonChimique,
        QuadrupleLiaisonChimique
    }

    [SerializeField] private RecipeType type;
}
