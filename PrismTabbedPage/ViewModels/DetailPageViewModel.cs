using System;
using Prism.Commands;
using Prism.Navigation;
using PrismTabbedPage.Interfaces;
using Unity;

namespace PrismTabbedPage.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;
        private readonly IMyTabbedPageSelectedTab _myTabbedPageSelectedTab;

        public DelegateCommand GoBackToTabChild1PageCommand { get; set; }

        public DelegateCommand GoBackToTabChild2PageCommand { get; set; }

        public DelegateCommand GoBackToTabChild3PageCommand { get; set; }

        public DetailPageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            this._myTabbedPageSelectedTab = unityContainer.Resolve<IMyTabbedPageSelectedTab>();

            Title = "Detail Page";

            GoBackToTabChild1PageCommand = new DelegateCommand(GoBackToTabChild1Page);

            GoBackToTabChild2PageCommand = new DelegateCommand(GoBackToTabChild2Page);

            GoBackToTabChild3PageCommand = new DelegateCommand(GoBackToTabChild3Page);
        }

        private void GoBackToTabChild1Page()
        {
            _myTabbedPageSelectedTab.SetSelectedTab(0);
            _navigationService.GoBackAsync();
        }

        private void GoBackToTabChild2Page()
        {
            _myTabbedPageSelectedTab.SetSelectedTab(1);
            _navigationService.GoBackAsync();
        }

        private void GoBackToTabChild3Page()
        {
            _myTabbedPageSelectedTab.SetSelectedTab(2);
            _navigationService.GoBackAsync();
        }
    }
}
