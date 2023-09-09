using UnityEngine;
using UnityEngine.Events;

public class DeliveryHandler : MonoBehaviour
{
    [SerializeField] DeliveryCounter _deliveryCounter;
    [SerializeField] private int _numberOfMistakes;

    private int _currentMistakes;

    public event UnityAction dan;

    private void Start()
    {
        _currentMistakes = 0;
    }

    private void OnAddMistake()
    {
        _currentMistakes++;

        if(_currentMistakes >= _numberOfMistakes)

    }
}
