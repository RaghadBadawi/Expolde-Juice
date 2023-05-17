using add_ingredients.Models;
using add_ingredients.View_models;
using System;
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
    public partial class OrderMenuPage : ContentPage
    {
        AdminOrderViewModel adminOrderViewModel;
        public OrderMenuPage()
        {
            InitializeComponent();
            adminOrderViewModel = new AdminOrderViewModel();
            BindingContext = adminOrderViewModel;
            OrderList.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }
        protected override async void OnAppearing()
        {
            try
            {
                var orders = await adminOrderViewModel.GetAll();
                if(orders.Count == 0)
                {
                    noOrdersLabel.IsVisible = true;
                    OrderList.IsVisible = false;
                }
                else
                {
                    OrderList.IsVisible = true;
                    OrderList.ItemsSource = null;
                    OrderList.ItemsSource = orders;
                    OrderList.IsRefreshing = false;
                }
            }
            catch (Exception ex)
            {
                // handle the exception here, e.g. display an error message
                Debug.WriteLine(ex.Message);
            }
            foreach (var item in OrderList.ItemsSource)
            {
                if(item is string && (string)item == "IN_PROGRESS")
                {
                    var cell = OrderList.TemplatedItems.OfType<ViewCell>().FirstOrDefault(v => v.View.FindByName("Question_Mark.png") != null);

                    // Get the Image control within the ViewCell
                    var image = cell.View.FindByName("Question_Mark.png") as Image;

                    // Do something with the Image
                    image.Source = "Clock_Settings.png";
                }
            }
        }

        private async void onOrderTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedOrder = e.Item as Order;
            if (selectedOrder != null)
            {
                await Navigation.PushAsync(new OrderDetailsPage(selectedOrder));
            }
        }

        private void orderSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}