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
    public partial class SignUpPage : ContentPage
    {
        //SignUpVM signUpVM;
        SignUpViewModel signUpViewModel;
        public SignUpPage()
        {
            InitializeComponent();
            signUpViewModel = new SignUpViewModel();
            BindingContext = signUpViewModel;
        }

        private void OnLogInTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Log_in());
        }
    }
}