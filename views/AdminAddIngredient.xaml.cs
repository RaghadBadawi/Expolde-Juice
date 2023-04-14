using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
namespace InsertIngredients
{
    public partial class InsertIngredient : ContentPage
    {
        public Entry EntryName => Name;
        public Editor Descreption => description;

        public InsertIngredient(ingredientModel ingredient)
        {
            InitializeComponent();
            if (ingredient != null)
            {
                Name.Text = ingredient.Name;
                description.Text = ingredient.Description;
            }
        }

        public InsertIngredient()
        {
            InitializeComponent();
        }

   




        private void save_Clicked(object sender, EventArgs e)
        {
            ingredientModel item = new ingredientModel();
            ingredientRepository ingredientRepository = new ingredientRepository();
            _ = ingredientRepository.AddTheIngredient(Name.Text, description.Text);
            Name.Text = string.Empty;
            description.Text = string.Empty;
            _ = DisplayAlert("Success", "Ingredient Added Successfully", "OK");

        }

    }
}
