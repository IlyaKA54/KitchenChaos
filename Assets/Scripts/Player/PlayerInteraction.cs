using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerCounterSelector _playerCounterSelector;
    
    private void OnEnable()
    {
        _playerInput.Interacted += OnInteracted;
        _playerInput.InteractedAlternate += OnInteractedAlternate;
    }
    private void OnDisable()
    {
        _playerInput.Interacted -= OnInteracted;
        _playerInput.InteractedAlternate -= OnInteractedAlternate;
    }

    private void OnInteracted()
    {
        if (_playerCounterSelector.HasCounter)
        {
            var interactingCounter = _playerCounterSelector.CurrentInteractingCounter;
            interactingCounter.Interact();
        }
    }

    private void OnInteractedAlternate()
    {
        if(_playerCounterSelector.CurrentInteractingCounter is IInteractableAlternate interactingCounter)
            interactingCounter.AlternateInteract();
    }
}
