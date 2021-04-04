using System;
using Prism.Commands;
using Prism.Navigation;
using PrismTabbedPage.Interfaces;
using Unity;

namespace PrismTabbedPage.ViewModels.Tabbar
{
    public class TabHomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;

        public DelegateCommand GoToDetailPageCommand { get; set; }

        public DelegateCommand<string> GoToNextTabCommand { get; set; }

        public TabHomeViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Tab Child 1";

            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);

            GoToNextTabCommand = new DelegateCommand<string>((param) => GoToNextTab(int.Parse(param)));
        }

        private async void GoToDetailPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/DetailPage");
            //await NavigationService.NavigateAsync(nameof(DetailPage));
        }

        private void GoToNextTab(int tabIndex)
        {
            _unityContainer.Resolve<IMyTabbedPageSelectedTab>().SetSelectedTab(tabIndex);
        }
    }
}
