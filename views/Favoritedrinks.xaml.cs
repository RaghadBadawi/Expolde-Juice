using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userprofile.ViewModels;
using Userprofile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Userprofile.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favoritedrinks : ContentPage
    {
        public string userEmail;
        Users me;
        private void itemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // to remove a orange square appear when cklic in a grid
            ((ListView)sender).SelectedItem = null;
        }

        public Favoritedrinks(string userEmail)
        {

            InitializeComponent();
            me = new Users();
            me.Email = userEmail;
            itemListView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Favoretedrinkmodel favoretedrinkmodel = new Favoretedrinkmodel();
            var favorite = await favoretedrinkmodel.GetAll();
            var filteredRecipes = favorite.Where(r => r.UserEmail == me.Email).ToList();
            itemListView.ItemsSource = null;
            itemListView.ItemsSource = filteredRecipes;
            itemListView.IsRefreshing = false;
        }

        private void FAVORETBUTON_Clicked(object sender, EventArgs e)
        {
            var addImageButton = (ImageButton)sender;

            if (addImageButton.Source != null && addImageButton.Source.ToString() == "File:Heart.png")
            {

                addImageButton.Source = "favorite.png";
            }
            else
            {
                addImageButton.Source = "Heart.png";
            }
        }
    }
}
