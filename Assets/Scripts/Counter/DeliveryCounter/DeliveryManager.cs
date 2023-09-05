using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private MenuSO _menuSO;
    [SerializeField] private int _maxNumberOfRecipes;
    [SerializeField] private float _recipeSpawnDelay;


    private List<CompleteProductRecipeSO> _waitingRecipes;
    private float _accamulatedTime;

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

                Debug.Log(newRecipe.ToString());
            }
        }
    }

    public void DeliveredMeal(PlateKitchenObject plateKitchen)
    {
        foreach (var recipe in _waitingRecipes)
        {
            if(plateKitchen.Ingredients.Count == recipe.Ingredients.Count)
            {
                int index = 0;

                foreach (var kitchenObjectSO in recipe.Ingredients)
                {
                    if (plateKitchen.Ingredients[index].CompareKitchenObject(kitchenObjectSO))
                    {
                        index++;
                        continue;
                    }
                }
            }
        }
    }

}
