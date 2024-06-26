using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsOnTheMenu.Admin.Mobile.ViewModels;

public partial class RecipeListItemViewModel : ObservableObject
{
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

    public RecipeListItemViewModel(
        Guid id,
        string name,
        string imageUrl,
        string recipeSource,
        List<string> ingredients
        )
    {

        Id = id;
        Name = name;
        ImageUrl = imageUrl;
        RecipeSource = recipeSource;
        Ingredients = ingredients;
    }
}
