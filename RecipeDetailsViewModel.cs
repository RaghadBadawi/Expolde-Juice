using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using add_ingredients.Views;
using add_ingredients.Models;

namespace add_ingredients.View_models
{
	public class RecipeDetailsViewModel :INotifyPropertyChanged
	{
        private string _name;
        private List<ingredientModel> _ingredients;
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

        public List<ingredientModel> SelectedIngredients
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

        public RecipeDetailsViewModel(Recipe recipe)
        {
            Name = recipe.Name;
            SelectedIngredients = recipe.Ingredients;
            Comment = recipe.Comment;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

