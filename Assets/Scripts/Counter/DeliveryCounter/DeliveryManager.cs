using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private MenuSO _menuSO;
    [SerializeField] private int _maxNumberOfRecipes;
    [SerializeField] private float _recipeSpawnDelay;

    private List<CompleteProductRecipeSO> _waitingRecipes;
    private float _accamulatedTime;

    public event UnityAction<CompleteProductRecipeSO> _recipeAdde;
    private void Start()
    {
        _waitingRecipes = new List<CompleteProductRecipeSO>();
    }

    private void Update()
    {
        if(_waitingRecipes.Count < _maxNumberOfRecipes)
        {
            _accamulatedTime += Time.deltaTime;

            if(_accamulatedTime >= _recipeSpawnDelay)
            {
                _accamulatedTime = 0;

                var newRecipe = _menuSO.GetRandomResipe();

                _waitingRecipes.Add(newRecipe);

                _recipeAdde?.Invoke(newRecipe);
            }
        }
    }

    public bool DeliveredMeal(PlateKitchenObject plateKitchen)
    {
        foreach (var recipe in _waitingRecipes)
        {
            if(plateKitchen.Ingredients.Count == recipe.Ingredients.Count)
            {
                var check = CompareWithRecipe(plateKitchen.Ingredients, recipe);

                if(plateKitchen.Ingredients.Count == check)
                {
                    _waitingRecipes.Remove(recipe);

                    return true;
                }

            }
        }

        return false;
    }

    private int CompareWithRecipe(List<KitchenObject> plateKitchen, CompleteProductRecipeSO completeRecipe)
    {
        int count = plateKitchen.Count;
        int index = 0;

        for (int i = 0; i < count; i++)
        {
            if (CheckIngredient(plateKitchen[index], completeRecipe.Ingredients))
                index++;
            else
                break;
        }

        return index;
    }

    private bool CheckIngredient(KitchenObject kitchenObject, List<KitchenObjectSO> kitchenObjects)
    {
        foreach(var obj in kitchenObjects)
        {
            if(kitchenObject.CompareKitchenObject(obj))
                return true;
        }

        return false;
    }

}
