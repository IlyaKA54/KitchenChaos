using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter _stoveCounter;
    [SerializeField] private GameObject _fryingPlate;
    [SerializeField] private GameObject _sprayParticleSystem;

    private void OnEnable()
    {
        _stoveCounter.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        _stoveCounter.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(bool state)
    {
        _fryingPlate.SetActive(state);
        _sprayParticleSystem.SetActive(state);
    }
}
