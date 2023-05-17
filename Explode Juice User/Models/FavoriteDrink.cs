using System;
using System.Collections.Generic;
using System.Text;

namespace add_ingredients.Models
{
   public class FavoriteDrink
    {
        public Recipe Recipe { get; set; }
        public string UserEmail { get; set; }
        public string Id { get; set; }
    }
}
