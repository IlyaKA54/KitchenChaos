using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    public void ChangeState(bool state)
    {
        gameObject.SetActive(state);
    }
}
