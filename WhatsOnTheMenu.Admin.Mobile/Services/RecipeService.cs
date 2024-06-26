
using WhatsOnTheMenu.Admin.Mobile.Models;
using WhatsOnTheMenu.Admin.Mobile.Repository;

namespace WhatsOnTheMenu.Admin.Mobile.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public Task<List<Recipe>> GetAllRecipesAsync()
    {
        return _recipeRepository.GetAllRecipesAsync();
    }

    public Task<Recipe> GetRecipeAsync(Guid id)
    {
        return _recipeRepository.GetRecipeAsync(id);
    }
}
