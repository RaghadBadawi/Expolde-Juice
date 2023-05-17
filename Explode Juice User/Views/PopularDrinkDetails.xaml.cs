using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using add_ingredients.View_models;
using add_ingredients.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopularDrinkDetails : ContentPage
    {
        readonly User me;
        readonly PopularDrink popularDrink;
        readonly FavoriteDrinkViewModel favoriteDrinkViewModel;
        readonly PopularDrinksDetailsViewModel popularDrinksDetailsViewModel;


        public PopularDrinkDetails(PopularDrink popularDrink1, User user)
        {
            InitializeComponent();
            popularDrink = popularDrink1;
            me = new User();
            me = user;
            favoriteDrinkViewModel = new FavoriteDrinkViewModel();
            favorite.BindingContext = popularDrink.Recipe;
            popularDrinksDetailsViewModel = new PopularDrinksDetailsViewModel(popularDrink1);
            BindingContext = popularDrinksDetailsViewModel;
        }

      


        private async void OrderButtonClicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Enter Your Order Name", "Please enter a name for your order:");
            if (!string.IsNullOrWhiteSpace(name))
            {

                await OrderViewModel.SaveRecipe(popularDrink.Recipe);

                await OrderViewModel.SaveOrder(name, popularDrink.Recipe, me, "pending");
                await Navigation.PushAsync(new TabbedPage(me));
            }
            else
            {
                await DisplayAlert("Error", "An error occurred during the order, please try again", "OK");
            }
        }

        private async void FavoriteButtonClicked(object sender, EventArgs e)
        {
            var favoriteImageButton = (ImageButton)sender;
            var favorite = (Recipe)favoriteImageButton.CommandParameter;

            if (favoriteImageButton.Source != null && favoriteImageButton.Source.ToString() == "File: Heart.png")
            {

            }
            else
            {
                favoriteImageButton.Source = "Heart.png";
                await favoriteDrinkViewModel.SaveFavoriteDrink(favorite, me.Email);
            }
            
        }

    }
}