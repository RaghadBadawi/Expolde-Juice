using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using add_ingredients.Models;
using add_ingredients.View_models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserOrderedDrinkDetails : ContentPage
    {
        
        public Order order;
        
        public OrderDetailsViewModel orderDetailsViewModel;
        public UserOrderedDrinkDetails(Order orderDetails)
        {
            InitializeComponent();
            order = orderDetails;
        
            orderDetailsViewModel = new OrderDetailsViewModel(order);
           
            BindingContext = orderDetailsViewModel;
            cancleButton.BindingContext = order;
        }
        public UserOrderedDrinkDetails()
        {
            InitializeComponent();
        }
        async void CancleOrderButtonClicked(System.Object sender, System.EventArgs e)
        {
            var wantDelete = await DisplayAlert("Cancel order?", "Do you want to cancel your order?", "Yes", "No");
            var cancelButton = cancleButton;
            if (wantDelete)
            {
                OrderViewModel orderViweModel = new OrderViewModel();
                var order = (Order)cancelButton.CommandParameter;
                var Id = order.Id;
                bool isDelete = await orderViweModel.Delete(Id);

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
    }
}