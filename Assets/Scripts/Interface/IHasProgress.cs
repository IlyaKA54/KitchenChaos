using UnityEngine.Events;

public interface IHasProgress
{
    public event UnityAction KitchenObjectGrabbed;
    public event UnityAction<float> ProgressChanged;
}
