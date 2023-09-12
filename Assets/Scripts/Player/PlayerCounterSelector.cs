using UnityEngine;

public class PlayerCounterSelector : MonoBehaviour
{
    [SerializeField] private float _interactionDistance;
    [SerializeField] private StartGame _startGame;

    private Counter _currentInteractingCounter;
    private Player _player;
    private bool _isStartingGame;
    public Counter CurrentInteractingCounter => _currentInteractingCounter;
    public bool HasCounter => _currentInteractingCounter != null;

    private void Start()
    {
        _player = GetComponent<Player>();
        _isStartingGame = false;
        _startGame.GameStarted += OnGameStarted;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, _interactionDistance) && _isStartingGame)
        {
            if (raycastHit.transform.TryGetComponent(out Counter counter))
            {
                if (counter == null || counter != _currentInteractingCounter)
                {
                    TryResetInteractingCounter();
                    SelectInteractingCounter(counter);
                }

            }
        }
        else
        {
            if (_currentInteractingCounter != null)
                TryResetInteractingCounter();
        }
    }
    private void TryResetInteractingCounter()
    {
        if (_currentInteractingCounter != null)
        {
            _currentInteractingCounter.ResetUser();
            _currentInteractingCounter = null;

        }
    }

    private void SelectInteractingCounter(Counter counter)
    {
        _currentInteractingCounter = counter;
        _currentInteractingCounter.InitAndChangeState(_player);
    }

    private void OnGameStarted()
    {
        _isStartingGame = true;

        _startGame.GameStarted -= OnGameStarted;
    }
}
