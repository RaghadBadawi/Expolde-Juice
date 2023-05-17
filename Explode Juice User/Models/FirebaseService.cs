using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace add_ingredients.Models
{
    class FirebaseService
    {
        private static readonly FirebaseClient firebase = new FirebaseClient("https://expolde-juice3-default-rtdb.firebaseio.com/");

        public static FirebaseClient Firebase
        {
            get { return firebase; }
        }
    }
}
