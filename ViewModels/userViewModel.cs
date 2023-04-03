using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;
using Userprofile.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;


namespace Userprofile.ViewModels
{
    public class userViewModel 
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://test-fe5e2-default-rtdb.firebaseio.com/");
       
        public userViewModel()
        {

            
        }
        public async Task<List<Users>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Users)).OnceAsync<Users>()).Select(item => new Users
            {
                
                FirstName = item.Object.FirstName,
                LastName = item.Object.LastName,
                Email = item.Object.Email,
                Password = item.Object.Password,
                Phone = item.Object.Phone,
                ID=item.Key
                
               

            }).ToList();
        }
        public async Task<Users> GetById(string id)
        {
            List<Users> users = await GetAll(); // Get all users from the database
            Users user = users.FirstOrDefault(u => u.ID == id); // Find the user with the specified ID

            return user;
        }
    }
   
    
   
}



