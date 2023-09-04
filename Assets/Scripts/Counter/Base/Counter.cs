using UnityEngine;

public abstract class Counter : MonoBehaviour
{
    [SerializeField] private SelectedCounter _selectedCounter;

    [SerializeField] protected Transform SpawnPoint;

    protected Player CurrentUser;

    public void InitAndChangeState(Player user)
    {
        CurrentUser = user;

        _selectedCounter.ChangeState(true);
    }

    public void ResetUser()
    {
        CurrentUser = null;

        _selectedCounter.ChangeState(false);
    }

    public abstract void Interact();

}
