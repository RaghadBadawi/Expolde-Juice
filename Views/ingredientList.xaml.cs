﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using story_5;
using System.Globalization;

namespace task1
{
    public partial class ingredientList : ContentPage
    {
        ingredientRepository ingredientrepository = new ingredientRepository();

        public ingredientList()
        {
            InitializeComponent();

           itemListView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });


       
             //_ = ingredientrepository.insertAsync();
   


        }






        private void itemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // to remove a orange square appear when cklic in a grid
            ((ListView)sender).SelectedItem = null;
        }



        private Task DisplayAlert(ChildQuery childQuery, string v)
        {
            throw new NotImplementedException();
        }

        private async void delete_Button_Clicked(object sender, EventArgs e)
        {


            var button = (ImageButton)sender;
           
            var ingredient = (ingredientModel)button.BindingContext;
            var Name = ingredient.Name; // get the name of the ingredient
            var wantDelete = await DisplayAlert("Delete?", $"are you sure to delete {Name}", "Yes", "No");

            if (wantDelete)
            {
                var repo = new ingredientRepository();
                bool isDelete = await repo.Delete(ingredient.Id);

                if (isDelete)
                {
                    await DisplayAlert("Success", $"{Name} has been deleted", "OK");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Error", $"{Name} delete fill", "OK");

                }

            }
            else
            {
                await DisplayAlert("Error", $"{Name} delete fill", "OK");

            }

        }

        protected override async void OnAppearing()
        {
            var students = await ingredientrepository.GetAll();
            itemListView.ItemsSource = null;
            itemListView.ItemsSource = students;
            itemListView.IsRefreshing = false;

        }
    }








}
