using System;
using System.Collections.Generic;
using System.Text;

namespace add_ingredients.Models
{
    public class Order
    {
        public string Name { get; set; }
        public Recipe Recipes { get; set; }
        public User User { get; set; }
        public string Id { get; set; }
        public string Status { get; set; }
    }
}
