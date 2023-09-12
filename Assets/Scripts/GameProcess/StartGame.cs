using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    [SerializeField] private int _time;
    [SerializeField] private int _delay;

    private float _accumulatedTime;

    public event UnityAction<int> TimeChanged;
    public event UnityAction GameStarted;  

    private void Start()
    {
        _accumulatedTime = 0;
        TimeChanged?.Invoke(_time);
    }

    private void Update()
    {
        _accumulatedTime += Time.deltaTime;

        if (_accumulatedTime >= _delay)
        {
            _accumulatedTime = 0;

            _time--;

            TimeChanged?.Invoke(_time);

            if (_time == 0)
            {
                GameStarted?.Invoke();

                enabled = false;
            }
        }

    }
}
