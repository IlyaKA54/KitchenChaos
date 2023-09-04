using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CuttingAnimation : MonoBehaviour
{
    [SerializeField] private CuttingCounter _cuttingCounter;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _cuttingCounter.Cuted += OnCuted;
    }

    private void OnDisable()
    {
        _cuttingCounter.Cuted -= OnCuted;
    }

    private void OnCuted()
    {
        _animator.SetTrigger("Cut");
    }
}
