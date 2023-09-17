using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private float _maxWaitTime;
    [SerializeField] private float _minWaitTime;

    private float _waitTime;
    private float _accumulatedTime;
    private int _gameScene;

    public event UnityAction<float> FieldChanged;

    private void Start()
    {
        _waitTime = Random.Range(_minWaitTime, _maxWaitTime);
        _accumulatedTime = 0;
        _gameScene = 2;
    }

    private void Update()
    {
        _accumulatedTime += Time.deltaTime;

        FieldChanged?.Invoke(_accumulatedTime / _waitTime);

        if (_accumulatedTime >= _waitTime)
            SceneManager.LoadScene(_gameScene);
    }
}
