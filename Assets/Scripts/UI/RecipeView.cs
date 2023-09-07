using System.Collections.Generic;
using UnityEngine;

public class RecipeView : MonoBehaviour
{
    [SerializeField] private RecipeTemplateUI _template;
    [SerializeField] private DeliveryManager _deliveryManager;

    private List<RecipeTemplateUI> _recipes;

    private void OnEnable()
    {
        _deliveryManager.RecipeAdde += OnRecipeAdde;
        _deliveryManager.RecipeRemoved += OnRecipeRemoved;
    }

    private void OnDisable()
    {
        _deliveryManager.RecipeAdde -= OnRecipeAdde;
        _deliveryManager.RecipeRemoved -= OnRecipeRemoved;
    }
    private void Start()
    {
        _recipes = new List<RecipeTemplateUI>();
    }

    private void OnRecipeAdde(CompleteProductRecipeSO completeProduct)
    {
        var newRecipeView = Instantiate(_template, transform);

        newRecipeView.SetRecipe(completeProduct);

        _recipes.Add(newRecipeView);
    }

    private void OnRecipeRemoved(CompleteProductRecipeSO completeProduct)
    {
        foreach (var recipe in _recipes)
        {
            if(recipe.CompareResipes(completeProduct))
            {
                recipe.Destroy();

                _recipes.Remove(recipe);

                break;
            }
        }
    }

}
