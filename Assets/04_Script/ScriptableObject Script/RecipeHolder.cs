using UnityEngine;
using static Recipe;

[CreateAssetMenu(fileName = "RecipeHolder", menuName = "Scriptable Objects/RecipeHolder")]
public class RecipeHolder : ScriptableObject
{
    public enum RecipeType
    {
        SimpleLiaisonChimique,
        DoubleLiaisonChimique,
        TripleLiaisonChimique,
        QuadrupleLiaisonChimique
    };

    [SerializeField] private RecipeType type;

    [ConditionalHide("type", (int)RecipeType.SimpleLiaisonChimique)]
    [SerializeField] public RecipeSimpleLiaisonChimique[] simpleLC;

    [ConditionalHide("type", (int)RecipeType.DoubleLiaisonChimique)]
    [SerializeField] public RecipeDoubleLiaisonChimique[] doubleLC;

    [ConditionalHide("type", (int)RecipeType.TripleLiaisonChimique)]
    [SerializeField] public RecipeTripleLiaisonChimique[] tripleLC;

    [ConditionalHide("type", (int)RecipeType.QuadrupleLiaisonChimique)]
    [SerializeField] public RecipeQuadrupleLiaisonChimique[] quadrupleLC;
}