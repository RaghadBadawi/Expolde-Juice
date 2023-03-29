using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using add_ingredients.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class add_ingredients : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }


        public add_ingredients()
        {
            InitializeComponent();



            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            //MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void AddImageButtonClicked(object sender, EventArgs e)
        {
            addImageButton.Source = "check.png";
        }

        private void DoneButtonClicked(object sender, EventArgs e)
        {
            popupFrame.IsVisible = false;
            // Do other things when the "Done" button is clicked
        }

        //private void Add_Clicked(object sender, EventArgs e)
        //{

        //}

        // Create an instance of the IngredientsViewModel class


        // Retrieve the list of ingredients from Firebase
        //protected new async void OnAppearing()
        //{
        //    base.OnAppearing();   
        //    IngredientsViewModel ingredientsViewModel = new IngredientsViewModel();

        //    // Call the GetIngredientsAsync method and wait for the results.
        //    List<Ingredient> ingredients = await ingredientsViewModel.GetIngredientsAsync();

        //}



    }
}