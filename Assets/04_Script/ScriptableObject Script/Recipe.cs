using UnityEngine;

public abstract class Recipe : ScriptableObject
{
    public enum RecipeType
    {
        SimpleLiaisonChimique,
        DoubleLiaisonChimique,
        TripleLiaisonChimique,
        QuadrupleLiaisonChimique
    }

    public string output;

    public abstract RecipeType Type { get; }

    public virtual string GetDescription()
    {
        return $"Recette : {Type}";
    }

    [CreateAssetMenu(fileName = "SimpleLiaisonChimique", menuName = "Scriptable Objects/Recipe/SimpleLiaisonChimique")]
    public class RecipeSimpleLiaisonChimique : Recipe
    {
        public override RecipeType Type => RecipeType.SimpleLiaisonChimique;
        public string atom1;
        public string atom2;
    }

    [CreateAssetMenu(fileName = "DoubleLiaisonChimique", menuName = "Scriptable Objects/Recipe/DoubleLiaisonChimique")]
    public class RecipeDoubleLiaisonChimique : Recipe
    {
        public override RecipeType Type => RecipeType.DoubleLiaisonChimique;
        public string atom1; 
        public string atom2;
        public string atom3;
    }

    [CreateAssetMenu(fileName = "TripleLiaisonChimique", menuName = "Scriptable Objects/Recipe/TripleLiaisonChimique")]
    public class RecipeTripleLiaisonChimique : Recipe
    {
        public override RecipeType Type => RecipeType.TripleLiaisonChimique;
        public string atom1;
        public string atom2;
        public string atom3;
        public string atom4;
    }

    [CreateAssetMenu(fileName = "QuadrupleLiaisonChimique", menuName = "Scriptable Objects/Recipe/QuadrupleLiaisonChimique")]
    public class RecipeQuadrupleLiaisonChimique : Recipe
    {
        public override RecipeType Type => RecipeType.QuadrupleLiaisonChimique;
        public string atom1;
        public string atom2;
        public string atom3;
        public string atom4;
        public string atom5;
    }
}


