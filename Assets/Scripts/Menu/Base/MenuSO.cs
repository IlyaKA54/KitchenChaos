using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New menu", menuName = "Menu/Create new menu", order = 51)]
public class MenuSO : ScriptableObject
{
    [SerializeField] private List<CompleteProductRecipeSO> _recipes;

    public List<CompleteProductRecipeSO> Recipes => _recipes;

    public CompleteProductRecipeSO GetRandomResipe()
    {
        var recipeIndex = Random.Range(0, _recipes.Count);

        return _recipes[recipeIndex];
    }
}
