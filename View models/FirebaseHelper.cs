using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userprofile.Models;

namespace Userprofile.ViewModel
{
    public class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://explodejuice-6dbab-default-rtdb.firebaseio.com/");

        public FirebaseHelper()
        {
        }
        public static async Task<bool> AddUser(string email, string firstName, string lastName, string password, string phone)
        {
            try
            {


                await firebase
                .Child("Users")
                .PostAsync(new Users() { Email = email, FirstName = firstName, LastName = lastName, Password = password, Phone = phone });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }


        public async Task Updateuser(string email, string firstName, string lastName, string phone, string password)
{
    var user = (await firebase.Child("Users").OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
    if (user != null)
    {
        admin.Object.FirstName = firstName;
        admin.Object.LastName = lastName;
        admin.Object.Phone = phone;
        admin.Object.Password = password;
        await firebase.Child("Users").Child(user.Key).PutAsync(user.Object);
    }
}

    }
}
