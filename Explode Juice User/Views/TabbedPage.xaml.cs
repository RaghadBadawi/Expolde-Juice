using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;


namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage
    {
        public  User me;

        public TabbedPage()
        {
            InitializeComponent();
        }
        public TabbedPage(User user)
        {
            InitializeComponent();
            me = new User();
            me = user;
            home.me = user;
            recipe.me = user;
            popularDrinks.me = user;
            favoriteDrinks.me = user;
            orderlist.me = user;
            NavigationPage.SetHasNavigationBar(this, false);
        }
      
    }
}