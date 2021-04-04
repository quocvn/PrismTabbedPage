using System;
using Prism.Commands;
using Prism.Navigation;
using PrismTabbedPage.Views.Account;

namespace PrismTabbedPage.ViewModels
{
    public class TabAccountViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToTabPageCommand { get; set; }

        public TabAccountViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;

            Title = "Account Page";

            GoToTabPageCommand = new DelegateCommand(GoToTabPage);
        }

        private async void GoToTabPage()
        {
            await _navigationService.NavigateAsync($"{nameof(UserListPage)}");
        }
    }
}
