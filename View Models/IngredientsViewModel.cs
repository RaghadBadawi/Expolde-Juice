using System;
using System.Collections.Generic;
using Xamarin.Forms;

using System.Linq;
using Newtonsoft.Json;
using Firebase.Database;
using System.Text;

using add_ingredients.Models;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace add_ingredients.View_models
{
    public class IngredientsViewModel : INotifyPropertyChanged
    {
        //private  FirebaseClient firebase;
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();

        public IngredientsViewModel()
        {

            // populate the fruit list
            string appleImageSource = new FileImageSource { File = "Apple.png" };
            Ingredients.Add(new Ingredient { IngredientName = "Apple", image = appleImageSource, IngredientType = "fruits" });
            string bananaImageSource = new FileImageSource { File = "banana.png" };
            Ingredients.Add(new Ingredient { IngredientName = "Banana", image = bananaImageSource, IngredientType = "fruits" });
            // add more fruits as needed
            //firebase = new FirebaseClient("https://explodejuice-6dbab-default-rtdb.firebaseio.com/");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public async Task<List<Ingredient>> GetIngredientsAsync()
        //{
        //    // Query Firebase database to retrieve ingredients data.
        //    var ingredientsData = await firebase.Child("ingredients").OnceAsync<Ingredient>();

        //    // Deserialize the retrieved data into a list of Ingredient objects.
        //    var ingredients = ingredientsData.Select(d => JsonConvert.DeserializeObject<Ingredient>(d.Object.ToString())).ToList();

        //    return ingredients;
        //}
    }
}
