using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsertIngredients.View_models
{
    internal class ingredientRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://explodejuice-6dbab-default-rtdb.firebaseio.com/");

        public async Task AddTheIngredient(string name, string description)
        {


            await firebaseClient
              .Child("ingredientModel")
              .PostAsync(new ingredientModel() { Name = name, Description = description });
        }
    }
}
