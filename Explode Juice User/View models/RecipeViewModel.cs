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
using add_ingredients.Views;

namespace add_ingredients.View_models
{
    public class RecipeViewModel
    {
        static readonly FirebaseClient firebaseClient = FirebaseService.Firebase;
        public List<Recipe> Recipes { get; set; }
        public List<Ingredient> SelectedIngredients { get; set; }

        public Recipe userRecipe;
        public string Comment;

        public RecipeViewModel(Recipe recipe )
        {
            userRecipe = new Recipe();
            SelectedIngredients = recipe.Ingredients;
            Comment = recipe.Comment; 
        }
        
        public RecipeViewModel()
        {

        }
        public async Task<List<Recipe>> GetAll()
        {
            try
            {
                var recipes = (await firebaseClient.Child(nameof(Recipe)).OnceAsync<Recipe>()).Select(item => new Recipe
                {
                    
                    Name = item.Object.Name,
                    Comment = item.Object.Comment,
                    ImageUrl = item.Object.ImageUrl,
                    UserEmail = item.Object.UserEmail,
                    Ingredients = item.Object.Ingredients,
                    Id = item.Key

                }).ToList();
                Recipes = recipes;
                return recipes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Recipes = null;
                throw new Exception("Error getting ingredients from Firebase");
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                await firebaseClient.Child(nameof(Recipe) + "/" + id).DeleteAsync();
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
