using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using add_ingredients.Views;
using Firebase.Database.Query;
using System.Threading.Tasks;
using add_ingredients.Models;
using Firebase.Database;
using System.Diagnostics;

namespace add_ingredients.View_models
{
    internal class PopularDrinksDetailsViewModel : INotifyPropertyChanged
    {
     
        private Recipe _recipe;
     

        public Recipe Recipe
        {
            get { return _recipe; }
            set
            {
                if (_recipe != value)
                {
                    _recipe = value;
                    OnPropertyChanged(nameof(Recipe));
                }
            }
        }






        public PopularDrinksDetailsViewModel(PopularDrink popularDrink)
        {
            Recipe = popularDrink.Recipe;

        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

     
    }
}
