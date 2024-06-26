
using CommunityToolkit.Mvvm.ComponentModel;
using WhatsOnTheMenu.Admin.Mobile.Models;

namespace WhatsOnTheMenu.Admin.Mobile.ViewModels;

public class RecipeViewModel : ObservableObject
{

    public Recipe Recipe { get; set; }

    public RecipeViewModel()
    {
        InitData();
    }
    private void InitData()
    {
        Recipe = new Recipe
        {
            Id = new Guid(),
            Name = "Cheese On Toast",
            ImageUrl = "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/k%2FPhoto%2FRecipe%20Ramp%20Up%2F2022-05-Cheese-on-Toast%2FIMG_6699",
            RecipeSource = "Internet",
            Ingredients = new List<String> { "Cheese", "Bread" }
        };
    }
}
