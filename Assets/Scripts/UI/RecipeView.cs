using System.Collections.Generic;
using UnityEngine;

public class RecipeView : MonoBehaviour
{
    [SerializeField] private RecipeTemplate _template;
    [SerializeField] private DeliveryManager _deliveryManager;

    private List<RecipeTemplate> _recipes;

    private void OnEnable()
    {
        _deliveryManager._recipeAdde += OnRecipeAdde;
    }

    private void OnDisable()
    {
        _deliveryManager._recipeAdde -= OnRecipeAdde;
    }
    private void Start()
    {
        _template = new RecipeTemplate();
    }

    private void OnRecipeAdde(CompleteProductRecipeSO completeProduct)
    {
        //var newRecipeView = Instantiate(_template, transform);

        //newRecipeView.SetText(completeProduct.Label);

        //_recipes.Add(newRecipeView);
    }

}
