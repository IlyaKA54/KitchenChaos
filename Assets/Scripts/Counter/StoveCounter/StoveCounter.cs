using UnityEngine;
using UnityEngine.Events;

public class StoveCounter : Counter, IHasProgress
{
    [SerializeField] private FryingRecipeSO[] _recipes;

    private KitchenObject _currentKitchenObject;
    private FryingRecipeSO _currentRecipe;
    private float _accumulatedTime;

    public bool HasKitchenObject => _currentKitchenObject != null;

    public event UnityAction<bool> StateChanged;
    public event UnityAction KitchenObjectGrabbed;
    public event UnityAction<float> ProgressChanged;

    private void Update()
    {
        if (_currentKitchenObject != null && _currentRecipe != null)
        {
            _accumulatedTime += Time.deltaTime;

            ChangeProgressBar();

            StateChanged?.Invoke(true);

            if (_accumulatedTime >= _currentRecipe.FryingTime)
            {
                _accumulatedTime = 0;

                ResetCurrentKitchenObject();

                _currentKitchenObject = CreateKicthenObject(_currentRecipe.OutputKitchenObject);

                SetRecipe();

                if (_currentRecipe == null)
                    StateChanged?.Invoke(false);
            }
        }
    }
    public override void Interact()
    {
        if (_currentKitchenObject == null)
        {
            if (CurrentUser.HasKitchenObject)
            {
                PickUpKitchenObjectAndSetParent();
                SetRecipe();
            }
        }
        else
        {
            if (!CurrentUser.HasKitchenObject)
            {
                GiveKitchenObject(_currentKitchenObject);

                KitchenObjectGrabbed?.Invoke();

                StateChanged?.Invoke(false);

                _accumulatedTime = 0;
            }
        }
    }

    private void GiveKitchenObject(KitchenObject kitchenObject)
    {
        _currentKitchenObject = null;

        CurrentUser.SetKitchenObject(kitchenObject);
    }

    private void PickUpKitchenObjectAndSetParent()
    {
        CurrentUser.GiveAndResetKitchenObject(out _currentKitchenObject);

        _currentKitchenObject.transform.parent = SpawnPoint;
        _currentKitchenObject.transform.position = SpawnPoint.position;
    }

    private void ResetCurrentKitchenObject()
    {
        _currentKitchenObject.Destroy();

        _currentKitchenObject = null;
    }

    private void SetRecipe()
    {
        _currentRecipe = TryGetResipe();
    }

    private FryingRecipeSO TryGetResipe()
    {
        if (_recipes.Length != 0)
        {
            foreach (var recipe in _recipes)
            {
                if (_currentKitchenObject.CompareKitchenObject(recipe.InputKitchenObject))
                    return recipe;
            }
        }

        return null;
    }

    private KitchenObject CreateKicthenObject(KitchenObjectSO kitchenObject)
    {
        return Instantiate(kitchenObject.KitchenObject, SpawnPoint.position, Quaternion.identity, transform);
    }

    private void ChangeProgressBar()
    {
        var progressNormalized = (float)_accumulatedTime / _currentRecipe.FryingTime;

        ProgressChanged?.Invoke(progressNormalized);
    }
}
