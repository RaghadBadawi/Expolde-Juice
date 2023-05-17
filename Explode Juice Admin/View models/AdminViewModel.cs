using add_ingredients.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace add_ingredients.View_models
{
    internal class AdminViewModel
    {
        public FirebaseClient firebase = FirebaseService.Firebase;

        public async Task UpdateAdmin(string email, string firstname, string lastName, string phone, string password)
        {
            var toUpdateAdmin = (await firebase
              .Child("AdminModels")
              .OnceAsync<Admin>()).Where(a => a.Object.Email == email).FirstOrDefault();

            await firebase
              .Child("AdminModels")
              .Child(toUpdateAdmin.Key)
              .PutAsync(new Admin() { Email = email, FirstName = firstname, LastName = lastName, Phone = phone, Password = password });
        }
    }
}