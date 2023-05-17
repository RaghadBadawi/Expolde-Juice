using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        Admin me;
     
        public AdminPage(Admin user)
        {
            InitializeComponent();
            me = new Admin();
            me = user;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        public AdminPage()
        {
            InitializeComponent();
        }
        private void OrderMenu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderMenuPage());
        }

        private void AddIngredients_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminAddIngredient());
        }

        private void IngredientsList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IngredientList());
        }

        void profileButtonClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Adminprofile(me));
        }
    }
}