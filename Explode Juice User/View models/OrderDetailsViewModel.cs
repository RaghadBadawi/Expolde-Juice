using add_ingredients.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
namespace add_ingredients.View_models
{
    public class OrderDetailsViewModel : INotifyPropertyChanged
    {
        static readonly FirebaseClient firebaseClient = FirebaseService.Firebase;
        private string _orderName;
        private string _name;
        private List<Ingredient> _ingredients;
        private string _comment;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public List<Ingredient> SelectedIngredients
        {
            get { return _ingredients; }
            set
            {
                if (_ingredients != value)
                {
                    _ingredients = value;
                    OnPropertyChanged(nameof(SelectedIngredients));
                }
            }
        }
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }
        public string OrderName
        {
            get { return _orderName; }
            set
            {
                if (_orderName != value)
                {
                    _orderName = value;
                    OnPropertyChanged(nameof(OrderName));
                }
            }
        }
        public OrderDetailsViewModel(Order order)
        {
            Name = order.Recipes.Name;
            SelectedIngredients = order.Recipes.Ingredients;
            Comment = order.Recipes.Comment;
            OrderName = order.Name;
        }
        public OrderDetailsViewModel(List<Ingredient> selectedIngredients)
        {
            SelectedIngredients = selectedIngredients;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public static async Task<Order> SaveOrder(string name, Recipe recipe, User user, string status)
        {
            Order order = new Order
            {
                Name = name,
                Recipes = recipe,
                User = user,
                Status = status

            };

            await firebaseClient
              .Child("Order")
              .PostAsync(order);

            return order;
        }
    }
}
