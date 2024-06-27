
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
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
    private readonly ILogger<RecipeViewModel> _logger;

    // Add a load async. This is sometimes not ready when needed. 
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        
        var recipeId = query["RecipeId"].ToString();
        _logger.LogInformation($"Query Attribute passed: 'RecipeId' {recipeId}");
        if (Guid.TryParse(recipeId, out var selectedId))
        {
            SelectedId = selectedId;
            GetRecipe(SelectedId);
        }
        
    }

    public RecipeViewModel(IRecipeService recipeService, ILogger<RecipeViewModel> logger)
    {
        _logger = logger;
        _recipeService = recipeService;

    }
    private async void GetRecipe(Guid Id)
    {
        _logger.LogInformation($"Getting recipes using the RecipeSerivce for ID' {Id}");
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
