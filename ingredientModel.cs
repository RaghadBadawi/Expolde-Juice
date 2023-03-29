using System;
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
	public class ingredientModel
	{
        public string image { get; set; }
        public string IngredientName { get; set; }
        public string ExpirationDate { get; set; }
    }


}

