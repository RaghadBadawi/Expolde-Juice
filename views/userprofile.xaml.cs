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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class userprofile : ContentPage
    {
        userViewModel userviewmodel = new userViewModel();
        public userprofile()
        {
            InitializeComponent();
            
        }
         private void Returnar_row_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Change_a_picture_Clicked(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)

        {
            //var button = (ImageButton)sender;
            //var edit = (Users)button.BindingContext;
            //edit.Password.InputTransparent = false;
            //edit.FirstName.InputTransparent = false;
            //edit.Email.InputTransparent = false;
            //edit.Phone.InputTransparent = false;
            //Save.IsVisible = true;
        }
        protected override async void OnAppearing()
        {
            string userId = "123"; // Replace with the ID of the user you want to retrieve
            Users user = await userviewmodel.GetById(userId);

            if (user != null)
            {
                // Display the user in your UI
              
                BindingContext = user;
                //user.FirstName ="hanan";
                //lastNameLabel.Text = user.LastName;
                //emailLabel.Text = user.Email;
                //phoneLabel.Text = user.Phone;
            }
            //    var user = await userviewmodel.GetAll();
            //    userprofilelist.ItemsSource = null;
            //    userprofilelist.ItemsSource = user;
            //    userprofilelist.IsRefreshing = false;

        }
        

        private void Button_Clicked(object sender, EventArgs e)
        {


        }
    }

}
