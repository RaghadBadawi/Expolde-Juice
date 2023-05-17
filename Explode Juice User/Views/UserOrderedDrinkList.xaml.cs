using System;
using add_ingredients.Models;
using add_ingredients.View_models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserOrderedDrinkList : ContentPage
    {
       public  User me;
        readonly UserOrderViewModel userOrderViewModel;
        public UserOrderedDrinkList(User user)
        {
            InitializeComponent();
            me = user;
            userOrderViewModel = new UserOrderViewModel();
            BindingContext = userOrderViewModel;

            OrderList.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }
        public UserOrderedDrinkList()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                var currentUserEmail = me.Email;
                var allOrders = await userOrderViewModel.GetAll();
                var filteredOrders = allOrders.Where(order => order.User.Email == currentUserEmail).ToList();
                if (filteredOrders.Count == 0)
                {

                    OrderList.IsVisible = false;
                }
                else
                {
                    OrderList.IsVisible = true;
                    OrderList.ItemsSource = null;
                    OrderList.ItemsSource = filteredOrders;
                    OrderList.IsRefreshing = false;
                }
            }
            catch (Exception ex)
            {
              
                Debug.WriteLine(ex.Message);
            }

        }
        private async void OrderTapped(object sender, ItemTappedEventArgs e)
        {
            Order selectedOrder = e.Item as Order;
            if (selectedOrder != null)
            {
                await Navigation.PushAsync(new UserOrderedDrinkDetails(selectedOrder));
            }
        }

        private void OrderSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}