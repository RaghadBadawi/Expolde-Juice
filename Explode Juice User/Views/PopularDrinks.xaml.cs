using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.View_models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using add_ingredients.Models;

namespace add_ingredients.Views
{
    public partial class PopularDrinks : ContentPage
    {        readonly PopularDrinksViewModel popularDrinkViewModel;
        
      
        public User me;
        private List<PopularDrink> Populardrink;
        public PopularDrinks()
        {
            InitializeComponent();
        }        public PopularDrinks(User user)        {            InitializeComponent();            popularDrinkViewModel = new PopularDrinksViewModel();                   BindingContext = popularDrinkViewModel;
            me = new User();
            me = user;
          


            popularDrinkListView.RefreshCommand = new Command(() =>            {                OnAppearing();            });        }            private void ItemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)        {
           
            ((ListView)sender).SelectedItem = null;        }        protected override async void OnAppearing()        {
            Populardrink = await popularDrinkViewModel.GetAll();
            popularDrinkListView.ItemsSource = null;
            popularDrinkListView.ItemsSource = Populardrink;
            popularDrinkListView.IsRefreshing = false;


        }        private void PopularDrink_Tapped(object sender, EventArgs e)        {            var viewCell = (ViewCell)sender;            var popularDrink = (PopularDrink)viewCell.BindingContext;
            Navigation.PushAsync(new PopularDrinkDetails(popularDrink, me));
        }        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)        {            SearchBar searchBar = (SearchBar)sender;            if (popularDrinkListView.ItemsSource == null)            {                popularDrinkListView.ItemsSource = Populardrink;            }            else            {                string searchText = searchBar.Text;                if (string.IsNullOrWhiteSpace(searchText))                {
                    
                    popularDrinkListView.ItemsSource = Populardrink;                }                else                {
                   
                    popularDrinkListView.ItemsSource = Populardrink.Where(d => d.Recipe.Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();                }            }        }


    }
}


