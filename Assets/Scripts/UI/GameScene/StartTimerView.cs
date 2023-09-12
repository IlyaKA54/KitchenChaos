using TMPro;
using UnityEngine;

public class StartTimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private StartGame _startGame;

    private void Start()
    {
        _startGame.TimeChanged += OnTimeChanged;
    }

    private void OnTimeChanged(int time)
    {
        _text.text = time.ToString();

        if (time == 0)
        {
            _startGame.TimeChanged -= OnTimeChanged;

            gameObject.SetActive(false);
        }
    }

}
