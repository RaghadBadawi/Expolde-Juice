using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using add_ingredients.Models;
namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        Users me;
        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(Users user)
        {
            InitializeComponent();
            me = new Users();
            me = user;
        }

        private void startCreateButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new selectIngredients(me));
        }

        private void profileButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new userprofile(me));
        }

        void recipeButton(System.Object sender, System.EventArgs e)
        {
            
            Navigation.PushAsync(new yourRecipe(me));

        }
    }
}
