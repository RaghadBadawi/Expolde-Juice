using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using add_ingredients.Models;
using add_ingredients.View_models;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Adminprofile : ContentPage
    {
        public Entry FirstNameEntry => FirstName;
        public Entry LastNameEntry => LastName;
        public Entry EmailEntry => Email;
        public Entry PhoneEntry => Phone;
        public Entry PasswordEntry => Password;
        public Adminprofile(AdminModels user)
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
        public Adminprofile()
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

        private void EditButton_Clicked(object sender, EventArgs e)

        {

            Password.InputTransparent = false;
            FirstName.InputTransparent = false;
            Email.InputTransparent = false;
            Phone.InputTransparent = false;
            Save.IsVisible = true;
        }
        private AdminViewModel firebaseHelper = new AdminViewModel();

        public async void Save_ClickedAsyns(object sender, EventArgs e)
        {
            await firebaseHelper.UpdateAdmin(EmailEntry.Text, FirstNameEntry.Text, LastNameEntry.Text, PhoneEntry.Text, PasswordEntry.Text);
            Save.IsVisible = false;
            await DisplayAlert("Success", "Information Updated Successfully", "OK");
            Password.InputTransparent = true;
            FirstNameEntry.InputTransparent = true;
            LastNameEntry.InputTransparent = true;
            Email.InputTransparent = true;
            Phone.InputTransparent = true;

        }
    }

}
