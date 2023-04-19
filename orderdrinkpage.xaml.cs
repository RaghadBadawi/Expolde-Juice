using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class orderdrinkpage : ContentPage
    {
        public orderdrinkpage()
        {
            InitializeComponent();
        }
        private void bookmark_Clicked(object sender, EventArgs e)
        {
              var addImageButton = (ImageButton)sender;

                if (addImageButton.Source != null && addImageButton.Source.ToString() == "File: Bookmark1.png")
                {

                    addImageButton.Source = "Bookmark.png";
                }
                else
                {
                    addImageButton.Source = "Bookmark1.png";
                }

           
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_4(object sender, EventArgs e)
        {

        }
    }
}
