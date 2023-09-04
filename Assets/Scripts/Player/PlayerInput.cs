using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction _playerInput;

    public event UnityAction Interacted;
    public event UnityAction InteractedAlternate;

    private void Awake()
    {
        _playerInput = new PlayerInputAction();
        _playerInput.Player.Enable();
        _playerInput.Player.Interact.performed += InteractPerformed;
        _playerInput.Player.InteractAlternate.performed += InteractAlternatePerformed;
    }

    private void InteractAlternatePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        InteractedAlternate?.Invoke();
    }

    private void InteractPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Interacted?.Invoke();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        var inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

}
