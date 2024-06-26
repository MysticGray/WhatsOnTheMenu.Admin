using WhatsOnTheMenu.Admin.Mobile.Models;

namespace WhatsOnTheMenu.Admin.Mobile.Repository;

public interface IRecipeRepository
{
    Task<List<Recipe>> GetAllRecipesAsync();
    Task<Recipe> GetRecipeAsync(Guid id);
}
