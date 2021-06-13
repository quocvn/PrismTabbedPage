using System;
using Prism.Commands;
using Prism.Navigation;
using PrismTabbedPage.Interfaces;
using PrismTabbedPage.Views;
using Unity;

namespace PrismTabbedPage.ViewModels.Tabbar
{
    public class TabHomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnityContainer _unityContainer;

        public DelegateCommand GoToDetailPageCommand { get; set; }

        public DelegateCommand<string> GoToNextTabCommand { get; set; }

        //public DelegateCommand<bool> ToggerSchedule { get; set; }

        public TabHomeViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Title = "Tab Child 1";

            GoToDetailPageCommand = new DelegateCommand(GoToDetailPage);

            GoToNextTabCommand = new DelegateCommand<string>((param) => GoToNextTab(int.Parse(param)));

            //ToggerSchedule = new DelegateCommand<bool>((value) => ExecuteSwitchCommand(value));
        }

        private async void GoToDetailPage()
        {
            await _navigationService.NavigateAsync(nameof(DetailPage));
        }

        private void GoToNextTab(int tabIndex)
        {
            _unityContainer.Resolve<IMyTabbedPageSelectedTab>().SetSelectedTab(tabIndex);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters == null) return;
            var index = parameters.GetValue<int>("TAB_INDEX");
            _unityContainer.Resolve<IMyTabbedPageSelectedTab>().SetSelectedTab(index);
        }


        //private void ExecuteSwitchCommand(bool value)
        //{
        //    Console.WriteLine("value: {0}", value.ToString());
        //}

    }
}
