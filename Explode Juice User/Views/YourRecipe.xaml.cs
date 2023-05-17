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
	public partial class YourRecipe : ContentPage
	{
        public User me;
        readonly RecipeViewModel recipeViewModel;
        readonly PopularDrinksViewModel popularDrinksViewModels;
        public YourRecipe(User user)
        {
            InitializeComponent();
            me = user;
            recipeViewModel = new RecipeViewModel();
            popularDrinksViewModels = new PopularDrinksViewModel();
            BindingContext = recipeViewModel;

            recipeList.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });

        }
        public YourRecipe()
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
            Recipe selectedRecipe = e.Item as Recipe;
            if (selectedRecipe != null)
            {
                await Navigation.PushAsync(new OrderYourDrink(selectedRecipe, me));
            }
        }

        private async void ShereImageButtonClicked(object sender, EventArgs e)
        {
            var shareImageButton = (ImageButton)sender;
          
            var selectedRecipe = (Recipe)shareImageButton.BindingContext;

            if (selectedRecipe != null)
            {
               var share = await DisplayAlert("Share Recipe", "Do you want to share your recipe with every one?", "Yes", "No");
                if (share)
                {
                    await popularDrinksViewModels.ShareDrink(selectedRecipe);
                }
            }
        }
        private void RecipeListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}



