using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;

namespace add_ingredients.View_models
{
     public class OrderViewModel
    {
        public List<Ingredient> SelectedIngredients { get; set; }

        static readonly FirebaseClient firebaseClient = FirebaseService.Firebase;

        public OrderViewModel(List<Ingredient> selectedIngredients)
        {
            SelectedIngredients = selectedIngredients;

        }
        public OrderViewModel()
        {

        }
        public static async Task<Recipe> SaveRecipe(Recipe userRecipe)
        {
            Recipe recipe = new Recipe
            {
                Name = userRecipe.Name,
                ImageUrl = userRecipe.ImageUrl,
                Comment = userRecipe.Comment,
                UserEmail = userRecipe.UserEmail,
                Ingredients = userRecipe.Ingredients
            };

            await firebaseClient
              .Child("Recipe")
              .PostAsync(recipe);

            return recipe;
        }
        public static async Task<Order> SaveOrder(string name, Recipe recipe , User user, string status)
        {
            Order order = new Order
            {
                Name = name,
                Recipes = recipe,
                User=user,
                Status = status
                
            };

            await firebaseClient
              .Child("Order")
              .PostAsync(order);

            return order;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                await firebaseClient.Child(nameof(Order) + "/" + id).DeleteAsync();
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
