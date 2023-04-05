
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace add_ingredients.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void startCreateButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new selectIngredients());
        }
    }
}
