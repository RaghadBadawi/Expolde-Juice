using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using System.Diagnostics;
using System.Linq;
using Userprofile.Models;
using Userprofile.ViewModels;
using Userprofile.ViewModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Firebase.Database.Query;
namespace Userprofile.ViewModels
{

    class Favoretedrinkmodel
    {
        public static FirebaseClient firebaseClient = new FirebaseClient("https://explodejuice-6dbab-default-rtdb.firebaseio.com/");
        public List<Recipe> Recipes { get; set; }
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

        //public async Task<List<Recipe>> GetFavoriteRecipes(string userEmail)
        //{

        //    try
        //    {
        //        //await Favoretedrinkmodel.firebaseClient.Child("favorite").OrderByChild("UserEmail").EqualTo(userEmail).OnceAsync<Recipe>();
        //        var recipes =await firebaseClient.Child(nameof(Recipe) + "/" + userEmail).OnceAsync<Recipe>();


        //        return recipes.Select(recipe => new Recipe
        //        {
        //            ImageUrl = recipe.Object.ImageUrl,
        //            Name = recipe.Object.Name,
        //            UserEmail = recipe.Object.UserEmail
        //        }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        
    }

   
}
