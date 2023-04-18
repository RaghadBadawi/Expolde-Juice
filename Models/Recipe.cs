using System;
using System.Collections.Generic;
using System.Text;

namespace Userprofile.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public List<ingredientModel> Ingredients { get; set; }
        public string UserEmail { get; set; }
        public string Id { get; set; }

    }
}