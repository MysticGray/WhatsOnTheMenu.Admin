
using WhatsOnTheMenu.Admin.Mobile.Models;

namespace WhatsOnTheMenu.Admin.Mobile.Services;

public interface IRecipeService
{
    Task<List<Recipe>> GetAllRecipesAsync();
    Task<Recipe> GetRecipeAsync(Guid id);
}
