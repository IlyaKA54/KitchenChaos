using UnityEngine;
using UnityEngine.Events;

public class CuttingCounter : Counter, IInteractableAlternate,IHasProgress
{
    [SerializeField] private CuttingRecipeSO[] _recipes;

    private KitchenObject _currentKitchenObject;
    private CuttingRecipeSO _currentRecipe;
    private int _cuttingProgress;

    public bool HasKitchenObject => _currentKitchenObject != null;

    public event UnityAction<float> ProgressChanged;
    public event UnityAction KitchenObjectGrabbed;
    public event UnityAction Cuted;

    public void AlternateInteract()
    {
        if (_currentRecipe != null && _currentKitchenObject != null)
        {
            Cuted?.Invoke();

            _cuttingProgress++;

            ChangeProgressBar();

            if (_cuttingProgress >= _currentRecipe.MaxCuttingProgress)
            {
                ResetCurrentKitchenObject();

                var spawnedKitchenObject = CreateKicthenObject(_currentRecipe.OutputKitchenObject);

                _currentKitchenObject = spawnedKitchenObject;

                _cuttingProgress = 0;

                _currentRecipe = null;
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

                if(_currentRecipe != null)
                {
                    ChangeProgressBar();
                }
            }
        }
        else
        {
            if (!CurrentUser.HasKitchenObject)
            {
                GiveKitchenObject(_currentKitchenObject);

                KitchenObjectGrabbed?.Invoke();

                _cuttingProgress = 0;
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

    private CuttingRecipeSO TryGetResipe()
    {
        if(_recipes.Length != 0)
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
        var progressNormalized = (float)_cuttingProgress / _currentRecipe.MaxCuttingProgress;

        ProgressChanged?.Invoke(progressNormalized);
    }
}
