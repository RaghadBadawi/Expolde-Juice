using add_ingredients.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace add_ingredients.View_models
{
    class UserOrderViewModel
    {
        readonly FirebaseClient firebaseClient = FirebaseService.Firebase;
        public List<Order> Orders { get; set; }
        public UserOrderViewModel()
        {
            Orders = new List<Order>();
        }
        public async Task<List<Order>> GetAll()
        {
            try
            {
                var orders = (await firebaseClient.Child(nameof(Order)).OnceAsync<Order>()).Select(item => new Order
                {
                    Name = item.Object.Name,
                    Recipes = item.Object.Recipes,
                    User = item.Object.User,
                    Id = item.Key,
                }).ToList();
                Orders = orders;
                return orders;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Orders = null;
                throw new Exception("Error getting orders from Firebase");
            }
        }
    }
}
