using System;
using Prism.Commands;
using Prism.Navigation;
using PrismTabbedPage.Views.Account;

namespace PrismTabbedPage.ViewModels.Tabbar
{
    public class TabAccountViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToUserListPageCommand { get; set; }

        public TabAccountViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;

            Title = "Account";

            GoToUserListPageCommand = new DelegateCommand(GoToUserList);
        }

        private async void GoToUserList()
        {
            await _navigationService.NavigateAsync($"{nameof(UserListPage)}");
        }
    }
}
