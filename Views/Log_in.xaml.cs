using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.View_models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Log_in : ContentPage
    {
        LoginViewModel login = new LoginViewModel();
        public Log_in()
        {
            InitializeComponent();
            BindingContext = login;
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            var email = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            var user = await LoginViewModel.GetUser(email);

            if (user != null && user.Password == password)
            {
                // Navigate to the next page if user exists and password matches
                await Navigation.PushAsync(new selectIngredients());
            }
            else
            {
                // Show an error message if user does not exist or password is incorrect
                await DisplayAlert("Login Error", "Invalid email or password", "OK");
            }

        }

    }
}
