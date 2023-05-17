using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using add_ingredients.Views;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;

namespace add_ingredients.View_models
{
    class  PopularDrinksViewModel
    {
        readonly FirebaseClient firebaseClient = FirebaseService.Firebase;
        public async Task<List<PopularDrink>> GetAll()
        {
            try
            {
                return (await firebaseClient.Child(nameof(PopularDrink)).OnceAsync<PopularDrink>()).Select(item => new PopularDrink
                {
                    Recipe = item.Object.Recipe,
                    Id = item.Key
                }).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }



        public async Task<PopularDrink> GetDrink(String id)
        {
            try
            {
                var result = await firebaseClient
           .Child(nameof(PopularDrink))
           .OrderBy(nameof(PopularDrink.Id))
           .EqualTo(id)
           .OnceAsync<PopularDrink>();
                var item = result.FirstOrDefault();

                if (item != null)
                {
                    return new PopularDrink
                    {
                        Id = item.Object.Id,
                        Recipe = item.Object.Recipe,
                       
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

      
        public async Task<PopularDrink> ShareDrink( Recipe recipe)
        {
            PopularDrink popularDrink = new PopularDrink
            {
                
                Recipe = recipe,
             
            };

            await firebaseClient
              .Child("PopularDrink")
              .PostAsync(popularDrink);

            return popularDrink;
        }
    }
}
