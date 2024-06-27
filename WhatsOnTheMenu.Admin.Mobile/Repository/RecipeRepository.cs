
using WhatsOnTheMenu.Admin.Mobile.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Serilog.Core;
namespace WhatsOnTheMenu.Admin.Mobile.Repository;

public class RecipeRepository : IRecipeRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<RecipeRepository> _logger;

    public RecipeRepository(IHttpClientFactory httpClientFactory, ILogger<RecipeRepository> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }
    public async Task<List<Recipe>> GetAllRecipesAsync()
    {
        using HttpClient client = _httpClientFactory.CreateClient("WOTMApiClient");

        try
        {
            List<Recipe>? recipies = await client.GetFromJsonAsync<List<Recipe>>(
                $"recipes",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));
            _logger.LogInformation($"Succesfully pulled recipes from the API. Total recipes {recipies.Count} ");
            return recipies ?? new List<Recipe>();
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to get recipes from the API: {message}", ex.Message);
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
        catch (Exception ex)
        {
            _logger.LogError("Failed to get recipe from the API: {message}", ex.Message);
            return null;
        }
    }
}
