using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using add_ingredients.Models;

namespace add_ingredients.View_models
{
    class UserProfileViewModel
    {
        static readonly FirebaseClient firebaseClient = FirebaseService.Firebase;
        public async Task Updateuser(string email, string firstName, string lastName, string phone, string password)
        {
            var user = (await firebaseClient.Child("User").OnceAsync<User>()).Where(a => a.Object.Email == email).FirstOrDefault();
            if (user != null)
            {
                user.Object.FirstName = firstName;
                user.Object.LastName = lastName;
                user.Object.Phone = phone;
                user.Object.Password = password;
                await firebaseClient.Child("User").Child(user.Key).PutAsync(user.Object);
            }
        }
    }
}
