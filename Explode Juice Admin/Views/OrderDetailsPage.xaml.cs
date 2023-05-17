using add_ingredients.Models;
using add_ingredients.View_models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailsPage : ContentPage
    {
        public Order order;
        public OrderDetailsViewModel orderDetailsViewModel;
        public AdminOrderViewModel adminOrderViewModel;
        public OrderDetailsPage(Order orderDetail)
        {
            InitializeComponent();
            order = new Order();
            adminOrderViewModel = new AdminOrderViewModel();
            order = orderDetail;
            orderDetailsViewModel = new OrderDetailsViewModel(order);
            BindingContext = orderDetailsViewModel;
            reject.BindingContext = order;
            done.BindingContext = order;
        }
        public OrderDetailsPage()
        {
            InitializeComponent();
        }

        private async void RejectButtonClicked(object sender, EventArgs e)
        {
            var wantDelete = await DisplayAlert("Reject order?", "Do you want to reject the order?", "Yes", "No");
            var rejectButton = reject;
            if (wantDelete)
            {
                var adminOrderViweModel = new AdminOrderViewModel();
                var order = (Order)rejectButton.CommandParameter;
                var Id = order.Id;
                bool isDelete = await adminOrderViweModel.Delete(Id);

                if (isDelete)
                {
                    OnAppearing();
                    await DisplayAlert("Success", "Your order has been deleted", "OK");

                }
                else
                {
                    await DisplayAlert("Error", "Your order delete fill", "OK");

                }
            }
        }

        private async void AcceptButtonClicked(object sender, EventArgs e)
        {
            await adminOrderViewModel.UpdateStatus("IN_PROGRESS", order.Id);
        }

        private async void DoneButtonClicked(object sender, EventArgs e)
        {

            var doneButton = done;
            var adminOrderViweModel = new AdminOrderViewModel();
            var order = (Order)doneButton.CommandParameter;
            var Id = order.Id;
            bool isDelete = await adminOrderViweModel.Delete(Id);

            if (isDelete)
            {
                OnAppearing();
                await DisplayAlert("Success", "Your order has been done", "OK");
                Navigation.RemovePage(this);

            }
            else
            {
                await DisplayAlert("Error", "Your order delete fill", "OK");

            }
        }
    }
}