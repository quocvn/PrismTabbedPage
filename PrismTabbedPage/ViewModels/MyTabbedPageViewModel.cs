using System;
using Prism.Navigation;
using PrismTabbedPage.Interfaces;
using Unity;
using Unity.Lifetime;

namespace PrismTabbedPage.ViewModels
{
    public class MyTabbedPageViewModel : ViewModelBase, IMyTabbedPageSelectedTab
    {
        private readonly IUnityContainer _unityContainer;

        private int _selectedTab;
        /// <summary>
        /// Binds to the View's property
        /// View-ViewModel communcation
        /// </summary>
        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                SetProperty(ref _selectedTab, value);
                //Title = $"My Tabbed Page - Tab [{SelectedTab + 1}]";
            }
        }

        public MyTabbedPageViewModel(INavigationService navigationService, IUnityContainer unityContainer)
            : base(navigationService)
        {
            //Title = $"My Tabbed Page - Tab [{SelectedTab + 1}]";

            this._unityContainer = unityContainer;

            // register this instance so we can access 
            // IMyTabbedPageSelectedTab anywhere in the code
            _unityContainer.RegisterInstance<IMyTabbedPageSelectedTab>(this, new ContainerControlledLifetimeManager());
        }

        public void SetSelectedTab(int tabIndex)
        {
            SelectedTab = tabIndex;
        }
    }
}
