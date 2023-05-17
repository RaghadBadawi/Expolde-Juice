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
    
    public partial class OrderYourDrink : ContentPage
    {
        readonly User me;  
        private readonly List<Ingredient> selectedIngredients;
        public Recipe recipe;
        private readonly bool fromRecipePage = false;
       
        public RecipeViewModel recipeViewModel;
        public RecipeDetailsViewModel recipeDetailsViewModel;

        public OrderViewModel orderViewModel; 
        public OrderYourDrink(List<Ingredient> selectedIngredients , User user)
        { 
            InitializeComponent();
            this.selectedIngredients = selectedIngredients;
            me = new User();
            recipe = new Recipe();

            me = user;
            orderViewModel = new OrderViewModel(selectedIngredients);
            
            BindingContext = orderViewModel;

            bookmark.BindingContext = recipe;
        }
        public OrderYourDrink(Recipe myRecipe,User user)
        {
            InitializeComponent();
            me = new User();
            me = user;
            recipeDetailsViewModel = new RecipeDetailsViewModel(myRecipe);
            recipe = new Recipe();
            recipe = myRecipe;
            BindingContext = recipeDetailsViewModel;
            bookmark.BindingContext = recipe;
            fromRecipePage = true;
            bookmark.Source = "bookmark.png";

        }

        public OrderYourDrink()
        {
            InitializeComponent();
       
        }


        async void SaveButtonClicked(System.Object sender, System.EventArgs e)
        {

            var saveImageButton = (ImageButton)sender;

            if (string.IsNullOrWhiteSpace(drinkName.Text))
            {
                await DisplayAlert("", "Please enter name for your drink", "OK");
                return;
            }
            if (saveImageButton.Source != null && saveImageButton.Source.ToString() == "File: Bookmark1.png")
            {
              await DisplayAlert("Saved Succefully", "Your recipe have been saved", "OK");


                saveImageButton.Source = "Bookmark.png";
                string imagePath = string.Empty;

                if (drinkImage.Source is FileImageSource fileImageSource)
                {
                    imagePath = fileImageSource.File;
                }
        
                recipe.Name = drinkName.Text;
                recipe.ImageUrl = imagePath;
                recipe.Ingredients = selectedIngredients;
                recipe.UserEmail = me.Email;
                recipe.Comment = commentEditor.Text;

                await OrderViewModel.SaveRecipe(recipe);
            }
            else if(fromRecipePage)
            {
                saveImageButton.Source = "Bookmark1.png";
                var wantDelete = await DisplayAlert("Unsave Recipe", "Do you want to unsave the recipe?", "Yes", "No");
                if (wantDelete)
                {
                    var recpievViweModel = new RecipeViewModel();
                    var recipe = (Recipe)saveImageButton.CommandParameter;
                    var Id = recipe.Id;
                    bool isDelete = await recpievViweModel.Delete(Id);

                    if (isDelete)
                    {
                        OnAppearing();
                        await DisplayAlert("Success", "Your recipe has been deleted", "OK");

                    }
                    else
                    {
                        await DisplayAlert("Error", "Your recipe delete fill", "OK");

                    }
                }

            }
        }



        async void OrderButtonClicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(drinkName.Text))
            {
                await DisplayAlert("", "Please enter name for your drink", "OK");
                return;
            }
            string name = await DisplayPromptAsync("Enter Your Order Name", "Please enter a name for your order:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!fromRecipePage)
                {
                    var imagePath = drinkImage.Source.ToString();
                    if (imagePath.StartsWith("file:"))
                    {
                        imagePath = imagePath.Substring("file:".Length);
                    }
                    recipe.Name = drinkName.Text;
                    recipe.ImageUrl = imagePath;
                    recipe.Ingredients = selectedIngredients;
                    recipe.UserEmail = me.Email;
                    recipe.Comment = commentEditor.Text;
                    await OrderViewModel.SaveRecipe(recipe);
                }
                await OrderViewModel.SaveOrder(name, recipe, me, "pending");
                await Navigation.PushAsync(new TabbedPage(me));
            }
            else
            {
                await DisplayAlert("Error", "An error occurred during the order, please try again", "OK");
            }
        }
    }
}