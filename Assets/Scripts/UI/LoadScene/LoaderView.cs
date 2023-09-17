using UnityEngine;
using UnityEngine.UI;

public class LoaderView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Loader _loader;

    private void OnEnable()
    {
        _loader.FieldChanged += OnFieldChanged;
    }
    private void OnDisable()
    {
        _loader.FieldChanged -= OnFieldChanged;
    }

    private void Start()
    {
        _image.fillAmount = 0;
    }

    private void OnFieldChanged(float value)
    {
        _image.fillAmount = value;
    }
}
