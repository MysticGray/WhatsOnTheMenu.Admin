using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsOnTheMenu.Admin.Mobile.Models;

public class Recipe
{

    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!    ;

    public string RecipeSource { get; set; } = default!    ;

    public List<string> Ingredients { get; set; } = default!;
}
