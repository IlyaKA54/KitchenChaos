using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private DeliveryHandler _deliveryHandler;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _timer.TimerEnded += OnGameEnded;
        _deliveryHandler.GameEnded+= OnGameEnded;
    }

    private void OnDisable()
    {
        _timer.TimerEnded -= OnGameEnded;
        _deliveryHandler.GameEnded += OnGameEnded;
    }

    private void OnGameEnded()
    {
        _gameOverScreen.SetActive(true);
        _text.text = _deliveryHandler.DeliveredMeals.ToString();
        //Time.timeScale = 0;
    }
}
