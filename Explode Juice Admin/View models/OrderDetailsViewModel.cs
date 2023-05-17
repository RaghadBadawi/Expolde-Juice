using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using add_ingredients.Views;
using add_ingredients.Models;

namespace add_ingredients.View_models
{
    public class OrderDetailsViewModel : INotifyPropertyChanged
    {
        private string _orderName;
        private string _customerName;
        private string _customerPhone;
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
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    OnPropertyChanged(nameof(CustomerName));
                }
            }
        }
        public string CustomerPhone
        {
            get { return _customerPhone; }
            set
            {
                if (_customerPhone != value)
                {
                    _customerPhone = value;
                    OnPropertyChanged(nameof(CustomerPhone));
                }
            }
        }

        public OrderDetailsViewModel(Order order)
        {
            Name = order.Recipes.Name;
            SelectedIngredients = order.Recipes.Ingredients;
            Comment = order.Recipes.Comment;
            OrderName = order.Name;
            CustomerName = order.User.FirstName;
            CustomerPhone = order.User.Phone;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

