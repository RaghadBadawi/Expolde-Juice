using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using Firebase.Database;
using System.Diagnostics;
using add_ingredients.Models;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;
using Xamarin.Essentials;

using Newtonsoft.Json;
using Firebase.Database.Query;

namespace add_ingredients.View_models
{
    internal class IngredientViewModel
    {
        FirebaseClient firebaseClient = FirebaseService.Firebase;


        public async Task<bool> Delete(string id)
        {
            try
            {
                await firebaseClient.Child(nameof(Ingredient) + "/" + id).DeleteAsync();
                return true;




            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }



        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Ingredient>> GetAll()
        {
            try
            {
                return (await firebaseClient.Child(nameof(Ingredient)).OnceAsync<Ingredient>()).Select(item => new Ingredient
                {
                    Name = item.Object.Name,
                    ImagePath = item.Object.ImagePath,
                    Description = item.Object.Description,
                    Id = item.Key
                }).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task AddTheIngredient(string name, string description)
        {


            await firebaseClient
              .Child("Ingredient")
              .PostAsync(new Ingredient() 
              { 
                  Name = name, 
                  Description = description,
                  ImagePath = name+".png"

              });
        }


    }
}
