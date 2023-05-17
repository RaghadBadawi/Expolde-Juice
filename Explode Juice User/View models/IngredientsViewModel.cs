using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using Firebase.Database;
using System.Diagnostics;
using add_ingredients.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Newtonsoft.Json;
namespace add_ingredients.View_models
{
    public class IngredientsViewModel 
    {
        readonly FirebaseClient firebaseClient = FirebaseService.Firebase;
        public List<Ingredient> Ingredients { get; set; }

        public IngredientsViewModel()
        {
            Ingredients = new List<Ingredient>();
        }

        public async Task<List<Ingredient>> GetAll()
        {
            try
            {
                var ingredients = (await firebaseClient.Child(nameof(Ingredient)).OnceAsync<Ingredient>()).Select(item => new Ingredient
                {
                    Name = item.Object.Name,
                    ImagePath = item.Object.ImagePath,
                    Description = item.Object.Description,
                    Id = item.Key
                }).ToList();
                Ingredients = ingredients;
                return ingredients;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Ingredients = null;
                throw new Exception("Error getting ingredients from Firebase");
            }
        }
    }
}
