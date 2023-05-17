using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database.Query;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientList : ContentPage
    {
        IngredientViewModel ingredientrepository = new IngredientViewModel();

        public IngredientList()
        {
            InitializeComponent();

            itemListView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });


        }


        private void itemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // to remove a orange square appear when cklic in a grid
            ((ListView)sender).SelectedItem = null;
        }



        private Task DisplayAlert(ChildQuery childQuery, string v)
        {
            throw new NotImplementedException();
        }

        private async void delete_Button_Clicked(object sender, EventArgs e)
        {


            var button = (ImageButton)sender;

            var ingredient = (Ingredient)button.BindingContext;
            var Name = ingredient.Name; // get the name of the ingredient
            var wantDelete = await DisplayAlert("Delete?", $"are you sure to delete {Name}", "Yes", "No");

            if (wantDelete)
            {
                var repo = new IngredientViewModel();
                bool isDelete = await repo.Delete(ingredient.Id);

                if (isDelete)
                {
                    OnAppearing();
                    await DisplayAlert("Success", $"{Name} has been deleted", "OK");

                }
                else
                {
                    await DisplayAlert("Error", $"{Name} delete fill", "OK");

                }

            }
           

        }

        protected override async void OnAppearing()
        {
            var ingredient = await ingredientrepository.GetAll();
            itemListView.ItemsSource = null;
            itemListView.ItemsSource = ingredient;
            itemListView.IsRefreshing = false;

        }
    }
}