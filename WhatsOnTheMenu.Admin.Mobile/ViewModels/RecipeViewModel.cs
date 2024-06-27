
using CommunityToolkit.Mvvm.ComponentModel;
using System.Xml.Linq;
using WhatsOnTheMenu.Admin.Mobile.Models;
using WhatsOnTheMenu.Admin.Mobile.Services;

namespace WhatsOnTheMenu.Admin.Mobile.ViewModels;


public partial class RecipeViewModel : ObservableObject, IQueryAttributable
{
    private readonly IRecipeService _recipeService;
    [ObservableProperty]
    private Guid _id;
    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private string _imageUrl;
    [ObservableProperty]
    private string _recipeSource;
    [ObservableProperty]
    private List<string> _ingredients;
    [ObservableProperty]
    private Guid _selectedId;

    // Add a load async. This is sometimes not ready when needed. 
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var recipeId = query["RecipeId"].ToString();
        if (Guid.TryParse(recipeId, out var selectedId))
        {
            SelectedId = selectedId;
        }
        GetRecipe(SelectedId);
    }

    public RecipeViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;
        //SelectedId = Guid.Parse("ed33f30b-0520-420e-8fc1-58820d6adf89");
    }
    private async void GetRecipe(Guid Id)
    {
        var @recipe = await _recipeService.GetRecipeAsync(Id);
        MapRecipeData(@recipe);
       
    }

    private void MapRecipeData(Recipe @recipe)
    {
        Id = @recipe.Id;
        Name = @recipe.Name;
        ImageUrl = @recipe.ImageUrl;
        RecipeSource = @recipe.RecipeSource;
        Ingredients = @recipe.Ingredients;
    }


}
