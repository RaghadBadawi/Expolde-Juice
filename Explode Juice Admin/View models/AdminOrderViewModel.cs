using System;
using System.Collections.Generic;
using System.Text;
using add_ingredients.Models;
using Firebase.Database;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Firebase.Database.Query;

namespace add_ingredients.View_models
{
    public class AdminOrderViewModel
    {
        FirebaseClient firebaseClient = FirebaseService.Firebase;

        public List<Order> Orders { get; set; }

        public AdminOrderViewModel()
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
                    Status = item.Object.Status
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
        public async Task<bool> Delete(string id)
        {
            try
            {
                await firebaseClient.Child(nameof(Order) + "/" + id).DeleteAsync();
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }
        public async Task<bool> UpdateStatus(string status, string id)
        {
            try
            {
                var order = (await firebaseClient.Child("Order").OnceAsync<Order>()).Where(a => a.Key == id).FirstOrDefault();
                if (order != null)
                {
                    order.Object.Status = status;
                    await firebaseClient.Child("Order").Child(order.Key).PutAsync(order.Object);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
