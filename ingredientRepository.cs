using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace ExplodeJuice
{
	public class ingredientRepository
	{
        FirebaseClient firebaseClient = new FirebaseClient("https://explodejuice-6dbab-default-rtdb.firebaseio.com/");
        private Button sender;

        async Task Delete_ingredAsync()
        {
            var button = (Button)sender;
            var item = (ingredientModel)button.BindingContext;
            _ = this.firebaseClient;
            await firebaseClient.Child("items").Child(item.IngredientName).DeleteAsync();



        }

        void Show_allIngred()
        {
            _=this.firebaseClient;



        }
    }
    
}

