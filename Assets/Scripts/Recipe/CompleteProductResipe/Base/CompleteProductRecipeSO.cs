using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New complete recipe", menuName = "Recipe/Create new complete recipe", order = 51)]
public class CompleteProductRecipeSO : ScriptableObject
{
    [SerializeField] private List<KitchenObjectSO> _ingredients;
    [SerializeField] private string _label;

    public List<KitchenObjectSO> Ingredients => _ingredients;
    public string Label => _label;
    
}
