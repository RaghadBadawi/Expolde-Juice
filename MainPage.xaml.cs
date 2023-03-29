using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq.Expressions;
using ExplodeJuice;

namespace task1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            List<Item> itemList = new List<Item>
            {
                      new Item { Name = "Item 1", Description = "Description for item 1", ImagePath = "https://t4.ftcdn.net/jpg/04/44/69/07/360_F_444690746_s4c1CO3KL2mffD4ny8HHD4iVsCGiZ4dR.jpg" },
                new Item { Name = "Item 2", Description = "Description for item 2", ImagePath = "https://t4.ftcdn.net/jpg/04/44/69/07/360_F_444690746_s4c1CO3KL2mffD4ny8HHD4iVsCGiZ4dR.jpg" },
                new Item { Name = "Item 3", Description = "Description for item 3", ImagePath ="https://t4.ftcdn.net/jpg/04/44/69/07/360_F_444690746_s4c1CO3KL2mffD4ny8HHD4iVsCGiZ4dR.jpg" },
            };

            itemListView.ItemsSource = itemList;
            ////////////////////////////////////

        }



        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch
            {

            }

        }



        private void itemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // to remove a orange square appear when cklic in a grid
            ((ListView)sender).SelectedItem = null;
        }


    }

    public class Item
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; internal set; }

    }
}
