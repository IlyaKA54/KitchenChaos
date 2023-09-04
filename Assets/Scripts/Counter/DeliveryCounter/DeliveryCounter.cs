public class DeliveryCounter : Counter
{
    public override void Interact()
    {
        if (CurrentUser.HasKitchenObject)
        {
            if (CurrentUser.KitchenObject is PlateKitchenObject)
            {
                KitchenObject kitchenObject;

                CurrentUser.GiveAndResetKitchenObject(out kitchenObject);

                kitchenObject.Destroy();
            }
        }
    }
}
