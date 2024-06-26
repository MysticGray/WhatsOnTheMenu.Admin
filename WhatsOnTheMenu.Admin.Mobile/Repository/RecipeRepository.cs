
using WhatsOnTheMenu.Admin.Mobile.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
namespace WhatsOnTheMenu.Admin.Mobile.Repository;

public class RecipeRepository : IRecipeRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RecipeRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<List<Recipe>> GetAllRecipesAsync()
    {
        using HttpClient client = _httpClientFactory.CreateClient("WOTMApiClient");

        try
        {
            List<Recipe>? recipies = await client.GetFromJsonAsync<List<Recipe>>(
                $"recipes",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return recipies ?? new List<Recipe>();
        }
        catch (Exception)
        {
            return new List<Recipe>();
        }
    }

    public async Task<Recipe> GetRecipeAsync(Guid id)
    {

        using HttpClient client = _httpClientFactory.CreateClient("WOTMApiClient");
        try
        {
            Recipe? @recipe = await client.GetFromJsonAsync<Recipe>(
                $"recipes/{id}",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return recipe;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
