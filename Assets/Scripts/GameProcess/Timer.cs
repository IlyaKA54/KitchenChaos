using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _amountOfTime;
    [SerializeField] private StartGame _startGame;
    [SerializeField] private DeliveryHandler _deliveryHandler;
    [SerializeField] private float _timeBonus;

    private float _startValue;
    private bool _isStartingGame;

    public event UnityAction TimerEnded;
    public event UnityAction<float> TimerChanged;

    private void Start()
    {
        _startValue = 1f;
        _isStartingGame = false;
        _startGame.GameStarted += OnGameStarted;
    }

    private void OnEnable()
    {
        _deliveryHandler.TimeUpped += OnTimeUpped;
    }

    private void OnDisable()
    {
        _deliveryHandler.TimeUpped -= OnTimeUpped;
    }
    private void Update()
    {
        if (_isStartingGame)
        {
            _startValue -= Time.deltaTime / _amountOfTime;

            TimerChanged?.Invoke(_startValue);

            if (_startValue <= 0f)
                TimerEnded?.Invoke();
        }
    }

    private void OnGameStarted()
    {
        _isStartingGame = true;

        _startGame.GameStarted -= OnGameStarted;
    }

    private void OnTimeUpped()
    {
        _startValue += _timeBonus;
    }

}
