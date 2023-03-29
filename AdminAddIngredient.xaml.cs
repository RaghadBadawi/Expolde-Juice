using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExplodeJuice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            //back to the previous screen
        }

        private void ImageButtonPicker_Clicked(object sender, EventArgs e)
        {
            //choose image from phone storage
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            //save details into database
        }
    }
}
