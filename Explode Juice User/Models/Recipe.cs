using System;
using System.Collections.Generic;

namespace add_ingredients.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string UserEmail { get; set; }
        public string Id { get; set; }

    }
}

