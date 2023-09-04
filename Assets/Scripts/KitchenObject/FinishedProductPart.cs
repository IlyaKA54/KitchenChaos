using System;
using UnityEngine;

[Serializable]
public class FinishedProductPart
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private GameObject _kitchenPart;
    [SerializeField] private GameObject _objectUI;

    public KitchenObjectSO KitchenObjectSO => _kitchenObjectSO;
    public GameObject KitchenPart => _kitchenPart;
    public GameObject ObjectUI => _objectUI;
}
