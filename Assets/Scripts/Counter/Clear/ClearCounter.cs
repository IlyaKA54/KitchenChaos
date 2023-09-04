public class ClearCounter : Counter
{
    private KitchenObject _currentKitchenObject;

    public override void Interact()
    {
        if (_currentKitchenObject == null)
        {
            if (CurrentUser.HasKitchenObject)
                PickUpKitchenObjectAndSetParent();
        }
        else
        {
            if (_currentKitchenObject is PlateKitchenObject plate && CurrentUser.HasKitchenObject)
            {
                if (plate.TryAddIngridient(CurrentUser.KitchenObject))
                {
                    KitchenObject removeKitchenObject;
                    CurrentUser.GiveAndResetKitchenObject(out removeKitchenObject);
                    removeKitchenObject.gameObject.SetActive(false);
                }
            }
            else if (CurrentUser.KitchenObject is PlateKitchenObject plateObject)
            {
                if (plateObject.TryAddIngridient(_currentKitchenObject))
                {
                    _currentKitchenObject.gameObject.SetActive(false);
                    _currentKitchenObject = null;
                }
            }
            else
            {
                GiveKitchenObject();
            }

        }
    }
    private void GiveKitchenObject()
    {
        CurrentUser.SetKitchenObject(_currentKitchenObject);
        _currentKitchenObject = null;
    }

    private void PickUpKitchenObjectAndSetParent()
    {
        CurrentUser.GiveAndResetKitchenObject(out _currentKitchenObject);
        _currentKitchenObject.transform.parent = SpawnPoint;
        _currentKitchenObject.transform.position = SpawnPoint.position;
    }
}
