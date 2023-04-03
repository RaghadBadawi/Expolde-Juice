using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Log_in : ContentPage
    {
        public Log_in()
        {
            InitializeComponent();
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            var logoPage = new logo();
            Navigation.PushAsync(new selectIngredients());
            
        }
    }
}