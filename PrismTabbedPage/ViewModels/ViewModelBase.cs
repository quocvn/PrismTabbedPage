using System;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismTabbedPage.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IApplicationLifecycleAware
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
            Console.WriteLine("OnNavigatedFrom");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
            Console.WriteLine("OnNavigatedTo");
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            Console.WriteLine("OnNavigatedFrom xx");
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            Console.WriteLine("OnNavigatedTo xx");
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            Console.WriteLine("OnNavigatingTo xx");
        }

        public virtual void Destroy()
        {
            Console.WriteLine("App Destroy");
        }

        public void OnResume()
        {
            Console.WriteLine("App OnResume");
            //throw new NotImplementedException();
        }

        public void OnSleep()
        {
            Console.WriteLine("App OnSleep");
            //throw new NotImplementedException();
        }
    }
}
