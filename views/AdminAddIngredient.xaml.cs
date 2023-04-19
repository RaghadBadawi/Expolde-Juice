using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using InsertIngredients.View_models;
using Xamarin.Forms;
namespace InsertIngredients
{
    public partial class InsertIngredient : ContentPage
    {
        public Entry EntryName => Name;
        public Editor Descreption => Description;

        public InsertIngredient(ingredientModel ingredient)
        {
            InitializeComponent();
            if (ingredient != null)
            {
                Name.Text = ingredient.Name;
                Description.Text = ingredient.Description;
            }
        }

        public InsertIngredient()
        {
            InitializeComponent();
        }

   




        private void Save_Clicked(object sender, EventArgs e)
        {
            ingredientModel item = new ingredientModel();
            ingredientRepository ingredientRepository = new ingredientRepository();
            _ = ingredientRepository.AddTheIngredient(Name.Text, Description.Text);
            Name.Text = string.Empty;
            Description.Text = string.Empty;
            _ = DisplayAlert("Success", "Ingredient Added Successfully", "OK");

        }

    }
}
