using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
namespace add_ingredients.Models
{
    public static class FirebaseService
    {
        private static FirebaseClient firebase = new FirebaseClient("https://expolde-juice3-default-rtdb.firebaseio.com/");

        public static FirebaseClient Firebase
        {
            get { return firebase; }
        }
    }
}
