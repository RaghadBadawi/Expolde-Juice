using System;
using System.Collections.Generic;
using ExplodeJuice.ViewModel;
using Xamarin.Forms;

namespace ExplodeJuice.Views
{	
	public partial class SignUpPage : ContentPage
	{
		SignUpVM signUpVM;

		public SignUpPage ()
		{

            InitializeComponent();
            signUpVM = new SignUpVM();
            //set binding    
            BindingContext = signUpVM;
        }
	}
}

