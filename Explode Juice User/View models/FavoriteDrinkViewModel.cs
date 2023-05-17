using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using System.Diagnostics;
using System.Linq;
using add_ingredients.Models;
using add_ingredients.View_models;
using Xamarin.Forms;
using System.Threading.Tasks;
using Firebase.Database.Query;
namespace add_ingredients.View_models
{
    class FavoriteDrinkViewModel
    {
        readonly FirebaseClient firebaseClient = FirebaseService.Firebase;
        public List<FavoriteDrink> FavoriteDrinks { get; set; }
        public async Task<List<FavoriteDrink>> GetAll()
        {
            try
            {
                var recipes = (await firebaseClient.Child(nameof(FavoriteDrink)).OnceAsync<FavoriteDrink>()).Select(item => new FavoriteDrink
                {
                    Recipe = item.Object.Recipe,
                    UserEmail = item.Object.UserEmail,
                    Id = item.Key

                }).ToList();
                FavoriteDrinks = recipes;
                return recipes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                FavoriteDrinks = null;
                throw new Exception("Error getting ingredients from Firebase");
            }
        }

        public async Task<FavoriteDrink> SaveFavoriteDrink(Recipe userRecipe, string email)
        {
            FavoriteDrink favorite = new FavoriteDrink
            {
                Recipe = userRecipe,
                UserEmail = email
               
            };

            await firebaseClient
              .Child("FavoriteDrink")
              .PostAsync(favorite);

            return favorite;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                await firebaseClient.Child(nameof(FavoriteDrink) + "/" + id).DeleteAsync();
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
