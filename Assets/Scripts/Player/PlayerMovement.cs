using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private PlayerInput _playerInput;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 inputVector = _playerInput.GetMovementVectorNormalized();

        if(inputVector != Vector2.zero)
        {
            Move(new Vector3(inputVector.x, 0, inputVector.y));
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * _moveSpeed * Time.deltaTime;

        AnimatePlayer();

        RotatePlayer(direction);
    }

    private void RotatePlayer(Vector3 direction)
    {
        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * _rotateSpeed);
    }

    private void AnimatePlayer()
    {
        _animator.SetTrigger("IsWalking");
    }
}
