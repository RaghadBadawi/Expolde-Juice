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
       public User me =new User();

        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(User user)
        {
            InitializeComponent();
            me = user;
           
        }

        private void StartCreateButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelectIngredients(me));
        }

        private void ProfileButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserProfile(me));
        }

    }
}