using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using signup.Models;
namespace signup.ViewModel
{
    public class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://test-fe5e2-default-rtdb.firebaseio.com/");

        public FirebaseHelper()
        {
        }
        public static async Task<bool> AddUser(string email, string firstName, string lastName, string password ,string phone)
        {
            try
            {


                await firebase
                .Child("Users")
                .PostAsync(new Users() { Email = email, FirstName = firstName, LastName = lastName, Password = password, Phone=phone });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

    }
}

