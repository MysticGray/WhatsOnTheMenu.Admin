using WhatsOnTheMenu.Admin.API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var recipes = new List<RecipeDto>
{
    new()
    {
        Id = Guid.Parse("ea3bf7ce-bf87-4fbc-ad82-c1196f023ad6"),
        Name = "Chicken Balti",
        ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/recipe-image-legacy-id-986455_10-cfc44d6.jpg?quality=90&webp=true&resize=300,272",
        RecipeSource = "BBC Good Food",
        Ingredients = new List<string>() { "Chicken", "Lime Juice", "Paprika", "Chilli Powder", "Onion", "Ginger" },
    },
    new()
    {
        Id = Guid.Parse("ed33f30b-0520-420e-8fc1-58820d6adf89"),
        Name = "Beans on Toast",
        ImageUrl = "https://i.pinimg.com/originals/bb/3a/a6/bb3aa6b53dfb065ec9118a872d50e6e8.jpg",
        RecipeSource = "Somthing book, page 10",
        Ingredients = new List<string>() { "Bread", "Beans", "Butter" },
    },
    new()
    {
        Id = Guid.Parse("ef9a9d96-7da6-48d9-9ef6-963efad29f01"),
        Name = "Oven-baked risotto",
        ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/recipe-image-legacy-id-373498_11-af7aea1.jpg?quality=90&webp=true&resize=300,272",
        RecipeSource = "BBC Good Food",
        Ingredients = new List<string>() { "risotto rice", "white wine ", " cherry tomatoes", "parmesan", "Smoked Bacon" },
    },
    new()
    {
        Id = Guid.Parse("4ad97e55-a50e-475f-aefb-928d7e62a920"),
        Name = "Sausage & soy fried rice",
        ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2023/12/Sausage-and-soy-fried-rice-641402f.jpg?quality=90&webp=true&resize=300,272",
        RecipeSource = "BBC Good Food",
        Ingredients = new List<string>() { "Spring Onion", "Ginger", "Sausage", "Courgettes", "Frozen Peas", "Jasmine Rice" },
    },
    new()
    {
        Id = Guid.Parse("44577e11-c099-4af0-b53f-9727718bfdf1"),
        Name = "Breakfast hash",
        ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2023/12/211220231703163239.jpeg?quality=90&webp=true&resize=300,272",
        RecipeSource = "BBC Good Food",
        Ingredients = new List<string>() { "Potatoes", "Back Bacon", "Red Pepper", "Eggs", "Feta" },
    }
};

app.MapGet("/recipes", ()
    => Results.Ok(recipes));

app.MapGet("/recipes/{id}", (Guid id) =>
{
    var @event = recipes.Find(e => e.Id == id);
    return @event is null
        ? Results.NotFound()
        : Results.Ok(@event);
});

app.Run();
