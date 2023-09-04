using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CuttingCounterAnimation : MonoBehaviour
{
    [SerializeField] private ContainerCounter _containerCounter;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _containerCounter.GrabbedKitchenObject += OnGrabbedKitchenObject;
    }
    private void OnDisable()
    {
        _containerCounter.GrabbedKitchenObject -= OnGrabbedKitchenObject;
    }

    private void OnGrabbedKitchenObject()
    {
        _animator.SetTrigger("OpenClose");
    }

}
