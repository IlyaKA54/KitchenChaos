using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _colorChangeBorder;
    [SerializeField] private Timer _timer;

    private Color _startColor;

    private void OnEnable()
    {
        _timer.TimerChanged += OnTimerChanged;
    }

    private void OnDisable()
    {
        _timer.TimerChanged -= OnTimerChanged;
    }

    private void Start()
    {
        _image.fillAmount = 1;
        _startColor = _image.color;
    }
    private void Update()
    {
        if (_image.fillAmount <= _colorChangeBorder)
            _image.color = Color.red;
        else
            _image.color = _startColor;
    }

    private void OnTimerChanged(float value)
    {
        _image.fillAmount = value;
    }
}
