public class TrashCounter : Counter
{
    public override void Interact()
    {
        if (CurrentUser.HasKitchenObject)
        {
            CurrentUser.GiveAndResetKitchenObject(out KitchenObject desroyObject);

            desroyObject.Destroy();
        }
    }
}
