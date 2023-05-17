using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectIngredients : ContentPage
    {
        readonly IngredientsViewModel ingredientsViewModel;
        readonly User me;
        public SelectIngredients(User user)
        {
            me = user;
            InitializeComponent();
            ingredientsViewModel = new IngredientsViewModel();
            BindingContext = ingredientsViewModel;

            ingredientList.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }
        protected override async void OnAppearing()
        {
            try
            {
                var ingredient = await ingredientsViewModel.GetAll();
                ingredientList.ItemsSource = null;
                ingredientList.ItemsSource = ingredient;
                ingredientList.IsRefreshing = false;
            }
            catch (Exception ex)
            {
               
                Debug.WriteLine(ex.Message);
            }

        }


        private bool ThereIsSelectedIngredient()
        {

            return selectedIngredients.Count > 0;
        }

        private bool popupShown = false;
        private readonly List<Ingredient> selectedIngredients = new List<Ingredient>();
        private void AddImageButtonClicked(object sender, EventArgs e)
        {
            var addImageButton = (ImageButton)sender;
            var ingredient = (Ingredient)addImageButton.BindingContext;

            if (addImageButton.Source != null && addImageButton.Source.ToString() == "File: Check.png")
            {

                addImageButton.Source = "plus.png";
                selectedIngredients.Remove(ingredient);
            }
            else
            {
                addImageButton.Source = "Check.png";
                selectedIngredients.Add(ingredient);
            }


            bool hasSelectedIngredients = ThereIsSelectedIngredient();

            if (hasSelectedIngredients && !popupShown)
            {
                popupShown = true;
                popupFrame.IsVisible = true;
            }
            else if (!hasSelectedIngredients && popupShown)
            {
                popupFrame.IsVisible = false;
                popupShown = false;
            }
        }
        private async Task SendSelectedIngredientsToOrderPage(List<Ingredient> selectedIngredients)
        {
            await Navigation.PushAsync(new OrderYourDrink(selectedIngredients, me));
        }
        private async void DoneImageButtonClicked(object sender, EventArgs e)
        {
            await SendSelectedIngredientsToOrderPage(selectedIngredients);
        }

        private void IngredientListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}