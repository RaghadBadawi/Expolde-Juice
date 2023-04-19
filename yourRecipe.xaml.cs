using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace add_ingredients.Views
{	
	public partial class yourRecipe : ContentPage
	{
        Users me;
        RecipeViewModel recipeViewModel;

        public yourRecipe (Users user)
		{
			InitializeComponent ();
            me = user;
            recipeViewModel = new RecipeViewModel();
            BindingContext = recipeViewModel;

            recipeList.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }
        public yourRecipe()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                
                var recipes = await recipeViewModel.GetAll();
                var filteredRecipes = recipes.Where(r => r.UserEmail == me.Email).ToList();
                recipeList.ItemsSource = null;
                recipeList.ItemsSource = filteredRecipes;
                recipeList.IsRefreshing = false;
            
            }
            catch (Exception ex)
            {
                // handle the exception here, e.g. display an error message
                Debug.WriteLine(ex.Message);
            }

        }


        private async void OnRecipeSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedRecipe = e.Item as Recipe;
            if (selectedRecipe != null)
            {
                await Navigation.PushAsync(new orderYourDrink(selectedRecipe, me));
            }
        }

    }
}



