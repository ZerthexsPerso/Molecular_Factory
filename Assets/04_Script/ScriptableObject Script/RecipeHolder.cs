using UnityEngine;

[CreateAssetMenu(fileName = "RecipeHolder", menuName = "Scriptable Objects/RecipeHolder")]
public class RecipeHolder : ScriptableObject
{
    public enum RecipeType
    {
        DoubleLiaisonChimique,
        TripleLiaisonChimique,
        QuadrupleLiaisonChimique
    };

    [SerializeField] private RecipeType type;

    [ConditionalHide("type", (int)RecipeType.DoubleLiaisonChimique)]
    [SerializeField] private Recipe[] doubleLC;

    [ConditionalHide("type", (int)RecipeType.TripleLiaisonChimique)]
    [SerializeField] private Recipe[] tripleLC;

    [ConditionalHide("type", (int)RecipeType.QuadrupleLiaisonChimique)]
    [SerializeField] private Recipe[] quadrupleLC;
}