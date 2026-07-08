using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptableObject), true)]
[CanEditMultipleObjects]
public class ConditionalHideEditor : Editor
{
    private static readonly Dictionary<Type, Dictionary<string, ConditionalHideAttribute>> cache
        = new Dictionary<Type, Dictionary<string, ConditionalHideAttribute>>(); // on range tout les scriptables object qu'on a déjà fait pour éviter de les faires plusieurs fois pcq ça sert à rien en vrai nan ?

    public override void OnInspectorGUI()
    {
        serializedObject.Update(); // check que rien de mauvais soit affiché

        var attrMap = GetAttributeMap(target.GetType()); // on appelle la fonction en bas et target c le scriptableObject qu'on vient afficher, on récup un annulaire avec les infos de si les champs ont un conditionalHide

        SerializedProperty prop = serializedObject.GetIterator(); // lit les variables de l'item
        bool enterChildren = true; // unityAPI en a besoin pour lancer la boucle et j'en sais pas plus, skill issue j'imagine

        while (prop.NextVisible(enterChildren)) // boucle pour chacune des valeurs
        {
            enterChildren = false; // unityAPI ils sont pas très malin si on me demande mais globalement on lui dit "va pas plus loin dans les enfants de l'item (il en a pas l'abruti)"

            if (prop.name == "m_Script") // check si ce qu'on regarde est modifiable ou pas si non il saute le reste
            {
                using (new EditorGUI.DisabledScope(true))
                    EditorGUILayout.PropertyField(prop);
                continue;
            }

            if (attrMap.TryGetValue(prop.name, out var attr)) // check si y'a un conditionnalHide avec la bonne condition à cette position de l'annulaire sinon on skip
            {
                SerializedProperty enumProp = serializedObject.FindProperty(attr.propertyName); // je pense que SerializadProperty on le voit pas tout les jours mais il fait plaisir à voir si on me demande
                if (enumProp != null && enumProp.enumValueIndex != attr.enumValue) // si la valeur de l'annulaire reliée est pas le bon conditionalHide ou si c'est pas une bonne proprieté on skip 
                    continue;
            }

            EditorGUILayout.PropertyField(prop, true); // si on arrive ici c que soit y'a un conditionalHide qui est bon soit y'a pas de condition donc on affiche
        }

        serializedObject.ApplyModifiedProperties(); // enregistre les modifs
    }

    private Dictionary<string, ConditionalHideAttribute> GetAttributeMap(Type type)
    {
        if (cache.TryGetValue(type, out var map))
            return map; // on check si le recap a déjà été fait sur la cible, si oui on la return

        map = new Dictionary<string, ConditionalHideAttribute>(); // si on en a pas dcp on doit en créer une nouvelle
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public |
                                     BindingFlags.NonPublic | BindingFlags.FlattenHierarchy); // ici on demande à la cible de donner tous les champs de la classe ça renvoie une fiche qu'on appelle un FieldInfo

        foreach (var field in fields) // on parcours les champs de notre fiche un par un
        {
            var attr = field.GetCustomAttribute<ConditionalHideAttribute>(); // on lui demande si il a un conditionalHide et il aura les valeurs si oui, sinon il sera null ce gros nul
            if (attr != null)
                map[field.Name] = attr; // si il est pas nul on le rajoute dcp et on lui un nom aussi
        }

        cache[type] = map; // quand on a fini on range, règle basique appris en cp
        return map; // et on la donne au proffesseur pcq on est bien élevé ici
    }
}