using UnityEngine;
using UnityEngine.Events;

public class DeliveryHandler : MonoBehaviour
{
    [SerializeField] DeliveryCounter _deliveryCounter;
    [SerializeField] private int _numberOfMistakes;

    private int _currentMistakes;

    public int DeliveredMeals { get; private set; }

    public event UnityAction GameEnded;
    public event UnityAction TimeUpped;

    private void Start()
    {
        _currentMistakes = 0;
        DeliveredMeals = 0;
    }

    private void OnEnable()
    {
        _deliveryCounter.MealDelivered += OnDeliverdMeal;
        _deliveryCounter.MistakeMaded += OnAddMistake;
    }

    private void OnDisable()
    {
        _deliveryCounter.MealDelivered -= OnDeliverdMeal;
        _deliveryCounter.MistakeMaded -= OnAddMistake;
    }
    private void OnDeliverdMeal()
    {
        DeliveredMeals++;
        TimeUpped?.Invoke();
    }

    private void OnAddMistake()
    {
        _currentMistakes++;

        if (_currentMistakes >= _numberOfMistakes)
            GameEnded?.Invoke();

    }
}
