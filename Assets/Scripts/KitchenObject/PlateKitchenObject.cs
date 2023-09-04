using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> _validKitchenObjects;

    private List<KitchenObject> _ingredients;

    public event UnityAction<KitchenObject> IngredientAdded;

    private void Awake()
    {
        _ingredients = new List<KitchenObject>();
    }

    public bool TryAddIngridient(KitchenObject ingredient)
    {
        if (CheckObject(ingredient))
        {
            _ingredients.Add(ingredient);

            IngredientAdded?.Invoke(ingredient);

            return true;
        }

        return false;
    }

    private bool CheckObject(KitchenObject ingredient)
    {
        return ÑheckObjectValidity(ingredient) && CheckIngridients(ingredient);
    }

    private bool ÑheckObjectValidity(KitchenObject kitchenObject)
    {
        foreach (var validObject in _validKitchenObjects)
        {
            if (kitchenObject.CompareKitchenObject(validObject))
                return true;
        }

        return false;
    }

    private bool CheckIngridients(KitchenObject kitchenObject)
    {
        foreach (var ingredient in _ingredients)
        {
            if (kitchenObject.Label == ingredient.Label)
                return false;
        }

        return true;
    }
}
