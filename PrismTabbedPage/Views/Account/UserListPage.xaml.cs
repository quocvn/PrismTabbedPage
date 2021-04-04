using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using PrismTabbedPage.Models;
using PrismTabbedPage.ViewModels;
using Xamarin.Forms;

namespace PrismTabbedPage.Views.Account
{
    public partial class UserListPage : ContentPage
    {
        public UserListPage()
        {
            InitializeComponent();
            BindingContext = new UserListPageViewModel(UserDialogs.Instance);
        }

        ~UserListPage()
        {
            BindingContext = null;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = ((ListView)sender).SelectedItem as User;
            if (user == null)
                return;

            //await Navigation.PushAsync(new DetailsPage(user));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Favorite invoked.", "OK");
        }

        async void OnShareSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Share invoked.", "OK");
        }

        async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Delete invoked.", "OK");
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            //put your refreshing logic here

            //make sure to end the refresh state

            list.IsRefreshing = false;
        }

        private void OnSearchChanged(object sender, TextChangedEventArgs e)
        {
            ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }
    }
}
