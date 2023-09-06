using UnityEngine;

public class DeliveryCounter : Counter
{
    [SerializeField] private DeliveryManager _manager;
    public override void Interact()
    {
        if (CurrentUser.HasKitchenObject && CurrentUser.KitchenObject is PlateKitchenObject plate)
        {
            if(_manager.DeliveredMeal(plate))
            {
                KitchenObject kitchenObject;

                CurrentUser.GiveAndResetKitchenObject(out kitchenObject);

                kitchenObject.Destroy();
            }
           
        }
    }
}
