using UnityEngine;
using UnityEngine.Events;

public class ContainerCounter : Counter
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    public event UnityAction GrabbedKitchenObject;
    public override void Interact()
    {
        if (!CurrentUser.HasKitchenObject)
        {
            GrabbedKitchenObject?.Invoke();

            var spawnedKistcheObject = CreateKitchenObject(_kitchenObjectSO.KitchenObject);

            CurrentUser.SetKitchenObject(spawnedKistcheObject);
        }
    }

    private KitchenObject CreateKitchenObject(KitchenObject kitchenObject)
    {
        var spawnedKistcheObject = Instantiate(_kitchenObjectSO.KitchenObject);
        spawnedKistcheObject.transform.position = Vector3.zero;

        return spawnedKistcheObject;
    }


}
