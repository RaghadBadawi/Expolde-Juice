using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using add_ingredients.Models;
using System.Threading.Tasks;

namespace add_ingredients.View_models
{
    public class LoginViewModel
    {
        public static FirebaseClient firebase = FirebaseService.Firebase;

        public static async Task<List<Admin>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Admin")
                .OnceAsync<Admin>()).Select(item =>
                new Admin
                {
                    FirstName = item.Object.FirstName,
                    LastName = item.Object.LastName,
                    Phone = item.Object.Phone,
                    Email = item.Object.Email,
                    Password = item.Object.Password
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<Admin> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Admin")
                .OnceAsync<Admin>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
    }
}
