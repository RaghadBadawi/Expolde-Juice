using System;
using System.Collections.Generic;
using System.Text;
using add_ingredients.Models;
namespace add_ingredients.View_models
{
    class OrderViewModel
    {
        public List<Ingredient> SelectedIngredients { get; set; }

        public OrderViewModel(List<Ingredient> selectedIngredients)
        {
            SelectedIngredients = selectedIngredients;
        }
    }
}
