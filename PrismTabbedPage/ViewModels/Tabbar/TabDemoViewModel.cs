using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using PrismTabbedPage.Models;
using PrismTabbedPage.Views.Account;

namespace PrismTabbedPage.ViewModels.Tabbar
{
    public class TabDemoViewModel : ViewModelBase
    {
        public ObservableCollection<DemoItem> DemoList { get; set; }

        public TabDemoViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Demo";
            DemoList = new ObservableCollection<DemoItem>() {
                new DemoItem
                {
                    Id = 1,
                    Name = "Kobe Bryant 1"
                }
            };
        }
    }
}
