using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DinoDiner.Menu;

namespace Website.Pages
{
    public class MenuModel : PageModel
    {
        public Menu Menu { get; protected set; } = new Menu();

        // backing variables for the form values
        [BindProperty]
        public string Search { get; set; }
        [BindProperty]
        public List<string> MenuCategory { get; set; } = new List<string>();
        [BindProperty]
        public float? MinimumPrice { get; set; }
        [BindProperty]
        public float? MaximumPrice { get; set; }
        [BindProperty]
        public List<string> ExcludedIngredients { get; set; } = new List<string>();

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            if (MenuCategory.Count > 0)
                Menu.FilterCategories(MenuCategory);
            if (Search != null)
                Menu.FilterNames(Search);
            if (MinimumPrice != null || MaximumPrice != null)
                Menu.FilterPrices(MinimumPrice, MaximumPrice);
            if (ExcludedIngredients.Count > 0)
                Menu.FilterIngredients(ExcludedIngredients);
        }
    }
}