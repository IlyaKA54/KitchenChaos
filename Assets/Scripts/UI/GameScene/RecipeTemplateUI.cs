using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeTemplateUI : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _imageContainer;
    [SerializeField] private Image _imageTemplate;

    public void SetRecipe(CompleteProductRecipeSO recipe)
    {
        SetText(recipe.Label);

        SetIcons(recipe.Ingredients);
    }

    private void SetText(string text)
    {
        _text.text = text;
    }

    private void SetIcons(List<KitchenObjectSO> ingredients)
    {
        foreach (var inredient in ingredients)
        {
            var icon = Instantiate(_imageTemplate, _imageContainer);
            icon.sprite = inredient.Sprite;
        }
    }

    public bool CompareResipes(CompleteProductRecipeSO completeProduct)
    {
        return _text.text == completeProduct.Label;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
