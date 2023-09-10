using UnityEngine;
using UnityEngine.Events;

public class DeliveryCounter : Counter
{
    [SerializeField] private DeliveryManager _manager;

    public event UnityAction MealDelivered;
    public event UnityAction MistakeMaded;
    public override void Interact()
    {
        if (CurrentUser.HasKitchenObject && CurrentUser.KitchenObject is PlateKitchenObject plate)
        {

            var check = _manager.DeliveredMeal(plate);

            ResetKitchenObject();

            if (check)
                MealDelivered?.Invoke();
            else
                MistakeMaded?.Invoke();
            
        }
    }

    private void ResetKitchenObject()
    {
        KitchenObject kitchenObject;

        CurrentUser.GiveAndResetKitchenObject(out kitchenObject);

        kitchenObject.Destroy();
    }
}
