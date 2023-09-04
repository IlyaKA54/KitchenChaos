using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    public string Label => _kitchenObjectSO.Label;
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public bool CompareKitchenObject(KitchenObjectSO kitchenObject)
    {
        return kitchenObject.Label == Label;
    }

}
