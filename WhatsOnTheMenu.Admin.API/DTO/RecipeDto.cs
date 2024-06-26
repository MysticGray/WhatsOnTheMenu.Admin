namespace WhatsOnTheMenu.Admin.API.DTO;

public class RecipeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string RecipeSource { get; set; } = default!;
    public List<string>? Ingredients { get; set; }
}
