using System;
using System.Collections.Generic;
using PrismTabbedPage.Models;
using PrismTabbedPage.Views.Account;
using Xamarin.Forms;

namespace PrismTabbedPage.Views.Tabbar
{
    public partial class TabDemo : ContentPage
    {
        public TabDemo()
        {
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem is not DemoItem item) return;

            switch (item.Id) {
                case 1:
                    await Navigation.PushAsync(new UserListPage());
                    break;
                default:
                    break;
            }
        }
    }
}
