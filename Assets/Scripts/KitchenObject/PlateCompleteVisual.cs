using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] private List<FinishedProductPart> _finishedProductParts;
    [SerializeField] private PlateKitchenObject _plateKitchenObject;

    private void OnEnable()
    {
        _plateKitchenObject.IngredientAdded += OnIngredientAdded;
    }

    private void OnDisable()
    {
        _plateKitchenObject.IngredientAdded -= OnIngredientAdded;
    }

    private void OnIngredientAdded(KitchenObject kitchenObject)
    {
        foreach (var part in _finishedProductParts)
        {
            if (kitchenObject.CompareKitchenObject(part.KitchenObjectSO))
                ChangeActiveFinishedProductObjects(part);
        }
    }

    private void ChangeActiveFinishedProductObjects(FinishedProductPart finishedProductPart)
    {
        finishedProductPart.KitchenPart.SetActive(true);
        finishedProductPart.ObjectUI.SetActive(true);
    }
}
