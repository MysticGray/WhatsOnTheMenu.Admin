
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WhatsOnTheMenu.Admin.Mobile.Models;
using WhatsOnTheMenu.Admin.Mobile.Pages;
using WhatsOnTheMenu.Admin.Mobile.Services;

namespace WhatsOnTheMenu.Admin.Mobile.ViewModels;

public partial class RecipeListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<RecipeListItemViewModel> _recipeList = new();
    //public List<RecipeListItemViewModel> RecipeList { get; set; }
    [ObservableProperty]
    private RecipeListItemViewModel? _selectedRecipe;

    private readonly IRecipeService _recipeService;

    public RecipeListViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;
        GetAllRecipes();
    }

    private async void GetAllRecipes() 
    {
        List<Recipe> recipes = await _recipeService.GetAllRecipesAsync();
        List<RecipeListItemViewModel> listItems = new();
        foreach (var @recipe in recipes)
        {
            listItems.Add(MapRecipeToRecipeRecipeListViewModel(@recipe));
        }
        RecipeList.Clear();
        RecipeList = listItems.ToObservableCollection();
    }

    [RelayCommand]
    public async Task NavigateToSelectedItem()
    {
        if (SelectedRecipe is not null)
        {
            var parameters = new Dictionary<string, object> { { "RecipeId", SelectedRecipe.Id } };
            await Shell.Current.GoToAsync(nameof(RecipePage), parameters);
        }

    }

    private RecipeListItemViewModel MapRecipeToRecipeRecipeListViewModel(Recipe @recipe)
    {
        return new RecipeListItemViewModel(
            @recipe.Id,
            @recipe.Name,
            @recipe.ImageUrl,
            @recipe.RecipeSource,
            @recipe.Ingredients
            );
    }

}
