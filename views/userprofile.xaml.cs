using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userprofile.Models;
using Userprofile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Userprofile.views
{
    public partial class userprofile : ContentPage
    {
        public Entry FirstNameEntry => FirstName;
        public Entry EmailEntry => Email;
        public Entry PhoneEntry => Phone;
        public Entry PasswordEntry => Password;

        UserViewModel userviewmodel = new UserViewModel();
        public userprofile(Users user)
        {
            InitializeComponent();
            if (user != null) { 
            FirstName.Text = user.FirstName;
            LastName.Text = user.LastName;
            Email.Text = user.Email;
            Phone.Text = user.Phone;
            Password.Text = user.Password;

            }
        }
        public userprofile()
        {
            InitializeComponent();
        }
        //protected override async void OnAppearing()
        //{
        // var user= await userviewmodel.GetAll();
          
        //}
         private void Returnar_row_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Change_a_picture_Clicked(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)

        {
            
            Password.InputTransparent = false;
            FirstName.InputTransparent = false;
            Email.InputTransparent = false;
            Phone.InputTransparent = false;
            Save.IsVisible = true;
        }
        

        private void Button_Clicked(object sender, EventArgs e)
        {


        }
    }

}
