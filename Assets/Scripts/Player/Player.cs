using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _holdingPoint;

    private KitchenObject _currentKitchenObject;

    public bool HasKitchenObject => _currentKitchenObject != null;
    public KitchenObject KitchenObject => _currentKitchenObject;

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        _currentKitchenObject = kitchenObject;

        PickUpObjectAndSetParent();
    }

    private void PickUpObjectAndSetParent()
    {
        _currentKitchenObject.transform.parent = _holdingPoint;
        _currentKitchenObject.transform.position = _holdingPoint.position;
    }

    public void GiveAndResetKitchenObject(out KitchenObject kitchenObject)
    {
        kitchenObject = _currentKitchenObject;
        _currentKitchenObject = null;
    }
}
