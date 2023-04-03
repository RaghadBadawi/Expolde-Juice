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
        FirebaseClient firebaseClient = new FirebaseClient("https://explodejuice-6dbab-default-rtdb.firebaseio.com/");
        public List<ingredientModel> Ingredients { get; set; }

        public IngredientsViewModel()
        {
            Ingredients = new List<ingredientModel>();
        }

        public async Task SaveDataLocally(List<ingredientModel> ingredients)
        {
            var json = JsonConvert.SerializeObject(ingredients);
            await SecureStorage.SetAsync("ingredients", json);
        }
        public async Task<List<ingredientModel>> LoadDataLocally()
        {
            var json = await SecureStorage.GetAsync("ingredients");
            if (json != null)
            {
                return JsonConvert.DeserializeObject<List<ingredientModel>>(json);
            }
            return null;
        }
        public async Task<List<ingredientModel>> GetAll()
        {
            try
            {
                var ingredients = (await firebaseClient.Child(nameof(ingredientModel)).OnceAsync<ingredientModel>()).Select(item => new ingredientModel
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
