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
    public partial class FavoriteDrinks : ContentPage
    {
        readonly FavoriteDrinkViewModel favoriteDrinkViewModel;
        public string userEmail;
        public User me;
        
        public FavoriteDrinks(User user)
        {

            InitializeComponent();
            me = new User();
            me = user;
            favoriteDrinkViewModel = new FavoriteDrinkViewModel();
            BindingContext = favoriteDrinkViewModel;
           
            itemListView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }
        public FavoriteDrinks()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            FavoriteDrinkViewModel favoretedrinkmodel = new FavoriteDrinkViewModel();
            var favorite = await favoretedrinkmodel.GetAll();
            var filteredRecipes = favorite.Where(r => r.UserEmail == me.Email).ToList();
            itemListView.ItemsSource = null;
            itemListView.ItemsSource = filteredRecipes;
            itemListView.IsRefreshing = false;
        }

        private void FavoriteDrinkSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // to remove a orange square appear when cklic in a grid
            ((ListView)sender).SelectedItem = null;
            
        }

        private async void FAVORETBUTON_Clicked(object sender, EventArgs e)
        {
            var favoriteImageButton = (ImageButton)sender;
            var favorite = (FavoriteDrink)favoriteImageButton.CommandParameter;
            var Id = favorite.Id;

            if (favoriteImageButton.Source != null && favoriteImageButton.Source.ToString() == "File: Heart.png")
            {

              

                favoriteImageButton.Source = "favorite.png";

                await favoriteDrinkViewModel.Delete(Id);

                itemListView.RefreshCommand = new Command(() =>
                {
                    OnAppearing();
                });
            }
            else
            {
                favoriteImageButton.Source = "Heart.png";
               
            }
        }

        private async void  FavoriteDrinkTapped(object sender, ItemTappedEventArgs e)
        {
            FavoriteDrink selectedDrink = e.Item as FavoriteDrink;
            if (selectedDrink != null)
            {
                await Navigation.PushAsync(new FavoriteDrinkDetails(selectedDrink , me));
            }
        }
    }
}