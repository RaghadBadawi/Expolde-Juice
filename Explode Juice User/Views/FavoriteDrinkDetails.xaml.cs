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
    public partial class FavoriteDrinkDetails : ContentPage
    {
        readonly FavoriteDrink favoriteDrink = new FavoriteDrink();
       
        readonly FavoriteDrinkDetailsViewModel FavoriteDrinkDetailsViewModel;
        readonly User me;
        public FavoriteDrinkDetails(FavoriteDrink favoriteDrinkParameter, User user)
        {
            InitializeComponent();
            favoriteDrink = favoriteDrinkParameter;
            me = new User();
            me = user;

            FavoriteDrinkDetailsViewModel = new FavoriteDrinkDetailsViewModel(favoriteDrink);
            BindingContext = FavoriteDrinkDetailsViewModel;
        }

        private async void OrderButtonClicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Enter Your Order Name", "Please enter a name for your order:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                await OrderViewModel.SaveRecipe(favoriteDrink.Recipe);
                await OrderViewModel.SaveOrder(name, favoriteDrink.Recipe, me, "pending");
                await Navigation.PushAsync(new TabbedPage(me));
            }
            else
            {
                await DisplayAlert("Error", "An error occurred during the order, please try again", "OK");
            }
        }
    }
}