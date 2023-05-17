using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.View_models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using add_ingredients.Models;
namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfile : ContentPage
    {
        public Entry FirstNameEntry => FirstName;
        public Entry EmailEntry => Email;
        public Entry PhoneEntry => Phone;
        public Entry PasswordEntry => Password;
        public Entry LastNameEntry => LastName;



        public UserProfile(User user)
        {
            InitializeComponent();
            if (user != null)
            {
                FirstName.Text = user.FirstName;
                LastName.Text = user.LastName;
                Email.Text = user.Email;
                Phone.Text = user.Phone;
                Password.Text = user.Password;

            }

        }
        public UserProfile()
        {
            InitializeComponent();
        }
       
       
        private void LogOutButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Log_in());
        }

        private void EditButtonClicked(object sender, EventArgs e)
        {
            FirstName.InputTransparent = false;
            LastName.InputTransparent = false;
            Phone.InputTransparent = false;
            Password.InputTransparent = false;


            Save.IsVisible = true;

            FirstName.BackgroundColor = (Color)Application.Current.Resources["Background"];
            LastName.BackgroundColor = (Color)Application.Current.Resources["Background"];
            Phone.BackgroundColor = (Color)Application.Current.Resources["Background"];
            Password.BackgroundColor = (Color)Application.Current.Resources["Background"];
        }

        private async void SaveButtonClicked(object sender, EventArgs e)
        {

            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
            await userProfileViewModel.Updateuser(EmailEntry.Text, FirstNameEntry.Text, LastNameEntry.Text, PhoneEntry.Text, PasswordEntry.Text);
            Save.IsVisible = false;
            await DisplayAlert("Success", "Information Updated Successfully", "OK");
            Password.InputTransparent = true;
            FirstNameEntry.InputTransparent = true;

            LastNameEntry.InputTransparent = true;
            Email.InputTransparent = true;
            Phone.InputTransparent = true;
        }
        private async void LogoutButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Log_in());
        }

    }

}
