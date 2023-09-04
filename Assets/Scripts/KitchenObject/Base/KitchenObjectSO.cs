using UnityEngine;

[CreateAssetMenu(fileName = "New kitchen object", menuName = "Kitchen object/Create new kitchen object", order = 51)]
public class KitchenObjectSO : ScriptableObject
{
    [SerializeField] private KitchenObject _kitchenObject;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _label;

    public KitchenObject KitchenObject => _kitchenObject;

    public Sprite Sprite => _sprite;

    public string Label => _label;
}
