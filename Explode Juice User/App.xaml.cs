using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using add_ingredients.Views;
using add_ingredients.View_models;
using Xamarin.Essentials;
namespace add_ingredients
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();
         
            MainPage = new NavigationPage(new Views.Logo());

            


        }

        protected override async void OnStart()
        {
            string username = Preferences.Get("Username", string.Empty);
            string password = Preferences.Get("Password", string.Empty);

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // Automatically log in the user using the stored credentials
                var email = username;
                var passwordlogin = password;

                var user = await LoginViewModel.GetUser(email);

                if (user != null && user.Password == password)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MainPage = new NavigationPage(new Views.TabbedPage(user));
                    });
                }
                else
                {
                    // Clear the stored credentials and display the login page
                    Preferences.Remove("Username");
                    Preferences.Remove("Password");
                    MainPage = new NavigationPage(new Log_in());
                }
            }
            else
            {
                MainPage = new NavigationPage(new Log_in());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
