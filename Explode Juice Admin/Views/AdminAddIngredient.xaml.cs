using add_ingredients.Models;
using add_ingredients.View_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminAddIngredient : ContentPage
    {
        public Entry EntryName => Name;
        public Editor Descreption => description;
        public AdminAddIngredient(Ingredient ingredient)
        {
            InitializeComponent();
            if (ingredient != null)
            {
                Name.Text = ingredient.Name;
                description.Text = ingredient.Description;
            }
        }
        public AdminAddIngredient()
        {
            InitializeComponent();
        }
        private void Save_Clicked(object sender, EventArgs e)
        {
            Ingredient item = new Ingredient();
            IngredientViewModel ingredientRepository = new IngredientViewModel();
            _ = ingredientRepository.AddTheIngredient(Name.Text, description.Text);
            Name.Text = string.Empty;
            description.Text = string.Empty;
            _ = DisplayAlert("Success", "Ingredient Added Successfully", "OK");

        }
    }
}