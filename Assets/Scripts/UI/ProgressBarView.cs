using UnityEngine;
using UnityEngine.UI;

public class ProgressBarView : MonoBehaviour
{
    [SerializeField] private GameObject _counter;
    [SerializeField] private Image _barView;
    [SerializeField] private GameObject _bar;

    private IHasProgress _hasProgressObject;
    private float _maxValue;

    private void Awake()
    {
        _hasProgressObject = _counter.GetComponent<IHasProgress>();

        if (_hasProgressObject == null)
            Debug.LogError($"The object {_counter} does not have a component that implements IHasProgress");
    }
    private void OnEnable()
    {
        _hasProgressObject.ProgressChanged += OnProgressChanged;
        _hasProgressObject.KitchenObjectGrabbed += Hide;
    }

    private void OnDisable()
    {
        _hasProgressObject.ProgressChanged -= OnProgressChanged;
        _hasProgressObject.KitchenObjectGrabbed -= Hide;
    }

    private void Start()
    {
        Hide();
        _maxValue = 1f;
    }
    private void OnProgressChanged(float value)
    {
        Show();

        _barView.fillAmount = value;

        if (_barView.fillAmount >= _maxValue)
            Hide();
    }

    private void Show()
    {
        _bar.gameObject.SetActive(true);
    }

    private void Hide()
    {
        _bar.gameObject.SetActive(false);
    }
}
