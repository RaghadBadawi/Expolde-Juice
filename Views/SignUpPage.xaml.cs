using System;
using System.Collections.Generic;
using signup.ViewModel;
using Xamarin.Forms;

namespace signup.Views
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

