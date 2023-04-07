using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Linq;
using System.ComponentModel.Design.Serialization;
using Xamarin.Essentials;

namespace story_5
{
    internal class ingredientRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://explodejuice-6dbab-default-rtdb.firebaseio.com/");


        public async Task <bool> Delete(string id)
        {
            try
            {
                await firebaseClient.Child(nameof(ingredientModel) + "/" + id).DeleteAsync();
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


        public async Task<List<ingredientModel>> GetAll()
        {
            try
            {
                return (await firebaseClient.Child(nameof(ingredientModel)).OnceAsync<ingredientModel>()).Select(item => new ingredientModel
                {
                    Name = item.Object.Name,
                    ImagePath = item.Object.ImagePath,
                    Description = item.Object.Description,
                    Id = item.Key
                }).ToList();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task insertAsync()
        {


            var newIngredient = new ingredientModel
            {
                Name = "Apple",
                Description = "tasty",
                ImagePath = "Apple.png"

            };
            await firebaseClient.Child("ingredientModel").PostAsync(newIngredient);

            var newingredient = new ingredientModel
            {
                Name = "Banana",
                Description = "tasty",
                ImagePath = "banana.png"

            };
            await firebaseClient.Child("ingredientModel").PostAsync(newingredient);

            var neingredient = new ingredientModel
            {
                Name = "Lemon",
                Description = "tasty",
                ImagePath = "lemon.png"

            };
            await firebaseClient.Child("ingredientModel").PostAsync(neingredient);

    
            var ngredient = new ingredientModel
            {
                Name = "Gerpes",
                Description = "tasty",
                ImagePath = "anab.png"

            };
            await firebaseClient.Child("ingredientModel").PostAsync(ngredient);


        }
    }
}
