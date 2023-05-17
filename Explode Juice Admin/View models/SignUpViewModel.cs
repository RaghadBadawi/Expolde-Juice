using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using add_ingredients.Views;
using add_ingredients.Models;
using Firebase.Database;
using Firebase.Database.Query;
namespace add_ingredients.View_models
{
    class SignUpViewModel: INotifyPropertyChanged
    {
        FirebaseClient firebaseClient = FirebaseService.Firebase;
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
            get { return phone; }
            set
            {
                phone = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Phone"));
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
        public  async Task<Admin> AddUser(string email, string firstName, string lastName, string password, string phone)
        {
            Admin admin = new Admin
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Phone = phone
            };

            await firebaseClient
              .Child("Admin")
              .PostAsync(admin);

            return admin;
        }
        private async void SignUp()
        {

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else if (password.Length < 8)
            {
                await App.Current.MainPage.DisplayAlert("Short Values", "The password is short", "OK");
            }
            else
            {
                Admin user = await AddUser(Email, FirstName, LastName, Password, Phone);
                if (user != null)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");

                    await App.Current.MainPage.Navigation.PushAsync(new AdminPage(user));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");
                }

            }
        }
    }
}
