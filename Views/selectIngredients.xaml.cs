using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class selectIngredients : ContentPage
    {
        public selectIngredients()
        {
            InitializeComponent();
            BindingContext = new IngredientsViewModel();
           
        }

        private void backButtonClicked(object sender, EventArgs e)
        {
         
        }
        
        private bool thereIsSelectedIngredient()
        {
          

            foreach (var item in ((IngredientsViewModel)BindingContext).Ingredients)
            {
                var viewCell = ingredientList.ItemTemplate.CreateContent() as ViewCell;
                viewCell.BindingContext = item;

                var imageButton = viewCell.FindByName<ImageButton>("addImageButton");
                if (imageButton.Source != null && imageButton.Source.ToString() == "File: Check.png")
                {
                  
                    return true;
                }
            }

            return false;

        }
        private bool popupShown = false;
        private void AddImageButtonClicked(object sender, EventArgs e)
        {
            var addImageButton = (ImageButton)sender;

            if (addImageButton.Source != null && addImageButton.Source.ToString()== "File: Check.png")
            {
                
                addImageButton.Source = "plus.png";
            }
            else
            {
                addImageButton.Source = "Check.png";
            }


            bool hasSelectedIngredients = thereIsSelectedIngredient();

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

        private void doneImageButtonClicked(object sender, EventArgs e)
        {

        }

       
    }
}