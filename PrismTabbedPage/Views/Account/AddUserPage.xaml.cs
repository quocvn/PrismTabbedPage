using System;
using System.Collections.Generic;
using PrismTabbedPage.Models;
using PrismTabbedPage.ViewModels;
using Xamarin.Forms;

namespace PrismTabbedPage.Views.Account
{
    public partial class AddUserPage : ContentPage
    {
        public AddUserPage(User user = null)
        {
            InitializeComponent();
            BindingContext = new AddUserPageViewModel(user);
        }
    }
}
