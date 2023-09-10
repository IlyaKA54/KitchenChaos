using UnityEngine;
using UnityEngine.Events;

public class DeliveryHandler : MonoBehaviour
{
    [SerializeField] DeliveryCounter _deliveryCounter;
    [SerializeField] private int _numberOfMistakes;

    private int _currentMistakes;
    private int _deliveredMeals;

    public event UnityAction<int> GameEnded;

    private void Start()
    {
        _currentMistakes = 0;
        _deliveredMeals = 0;
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
        _deliveredMeals++;

        Debug.Log(_deliveredMeals);
    }

    private void OnAddMistake()
    {
        _currentMistakes++;

        Debug.Log(_currentMistakes);

        //if(_currentMistakes >= _numberOfMistakes)
        //    GameEnded?.Invoke(_deliverdMeals);

    }
}
