using System;
using System.ComponentModel;
using Xamarin.Forms;
using ExplodeJuice.Views;

namespace ExplodeJuice.ViewModel
{
    public class SignUpVM : INotifyPropertyChanged
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        private string phone;
        public string Phone
        {
            get { return firstName; }
            set
            {
                phone = value;
                PropertyChanged(this, new PropertyChangedEventArgs("phone"));
            }
        }
        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                        App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                });
            }
        }
        private async void SignUp()
        {

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                var user = await FirebaseHelper.AddUser(Email, FirstName, LastName, Password,Phone);
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                 
                    await App.Current.MainPage.Navigation.PushAsync(new WellcomPage(Email));
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");

            }
        }
    }
}

