using UnityEngine;

[CreateAssetMenu(fileName = "New frying recipe", menuName = "Recipe/Create new frying recipe", order = 51)]
public class FryingRecipeSO : ScriptableObject
{
    [SerializeField] private KitchenObjectSO _inputKitchenObject;
    [SerializeField] private KitchenObjectSO _outputKitchenObject;
    [SerializeField] private float _fryingTime;

    public KitchenObjectSO OutputKitchenObject => _outputKitchenObject;

    public KitchenObjectSO InputKitchenObject => _inputKitchenObject;

    public float FryingTime => _fryingTime;
}
