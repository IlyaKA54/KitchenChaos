using UnityEngine;

[CreateAssetMenu(fileName = "New cutting recipe", menuName = "Recipe/Create new cutting recipe", order = 51)]
public class CuttingRecipeSO : ScriptableObject
{
    [SerializeField] private KitchenObjectSO _inputKitchenObject;
    [SerializeField] private KitchenObjectSO _outputKitchenObject;
    [SerializeField] private int _maxCuttingProgress;

    public KitchenObjectSO InputKitchenObject => _inputKitchenObject;
    public KitchenObjectSO OutputKitchenObject => _outputKitchenObject;
    public int MaxCuttingProgress => _maxCuttingProgress;
}
