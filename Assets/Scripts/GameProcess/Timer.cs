using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _amountOfTime;

    private float _startValue = 1f;

    public event UnityAction TimerEnded;
    public event UnityAction<float> TimerChanged;

    private void Update()
    {
        _startValue -= Time.deltaTime / _amountOfTime;

        TimerChanged?.Invoke(_startValue);

        if (_startValue < 0f)
            TimerEnded?.Invoke();
    }


}
