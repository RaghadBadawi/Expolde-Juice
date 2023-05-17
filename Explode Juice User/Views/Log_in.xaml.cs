using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.View_models;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Log_in : ContentPage
    {
        readonly LoginViewModel login = new LoginViewModel();
        
        public Log_in()
        {
            InitializeComponent();
            BindingContext = login;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            var email = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            var user = await LoginViewModel.GetUser(email);

            if (user != null && user.Password == password)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushAsync(new TabbedPage(user));


                });
            
            }
            else
            {
                await DisplayAlert("Login Error", "Invalid email or password", "OK");
            }

        }

        private void OnSignUpTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        private void RemmemberMeCheckBoxClicked(object sender, CheckedChangedEventArgs e)
        {
            if (checkBoxButton.IsChecked)
            {
                Preferences.Set("Username", UsernameEntry.Text);
                Preferences.Set("Password", PasswordEntry.Text);
            }
        }
    }
}