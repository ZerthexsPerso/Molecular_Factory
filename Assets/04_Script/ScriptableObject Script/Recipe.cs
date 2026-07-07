using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable Objects/Recipe")]
public class Recipe : ScriptableObject
{
    public enum RecipeType
    {
        Pipi,
        Caca,
        Pet
    };

    [SerializeField] private RecipeType type;

    [ConditionalHide("type", (int)RecipeType.Pipi)]
    [SerializeField] private int pipiValue;

    [ConditionalHide("type", (int)RecipeType.Caca)]
    [SerializeField] private float cacaValue;

    [ConditionalHide("type", (int)RecipeType.Pet)]
    [SerializeField] private string petValue;
}