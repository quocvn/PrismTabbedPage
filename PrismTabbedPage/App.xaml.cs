using Acr.UserDialogs;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismTabbedPage.Resources;
using PrismTabbedPage.Views;
using PrismTabbedPage.Views.Account;
using PrismTabbedPage.Views.Tabbar;
using Xamarin.Forms;

// Register material font
[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias = "Material")]
[assembly: ExportFont("MaterialIconsOutlined-Regular.otf", Alias = "Material-Outlined")]
namespace PrismTabbedPage
{
    public partial class App : PrismApplication
    {
        bool IsShownAlert = false;

        public App() : this(null) { }

        public App(IPlatformInitializer initializer = null) : base(initializer) {
            // Register for connectivity changes, be sure to unsubscribe when finished
            CrossConnectivity.Current.ConnectivityTypeChanged += Connectivity_ConnectivityChangedAsync;
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MyTabbedPage");
        }

        protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterRequiredTypes(containerRegistry);

            //containerRegistry.RegisterSingleton<NLogLogger>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MyTabbedPage>();
            containerRegistry.RegisterForNavigation<UserListPage>();
            containerRegistry.RegisterForNavigation<DetailPage>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void Connectivity_ConnectivityChangedAsync(object sender, ConnectivityTypeChangedEventArgs args)
        {
            if (!args.IsConnected)
            {
                ShowAlertInternet();
            }
        }

        public void ShowAlertInternet()
        {
            if (!IsShownAlert)
            {
                IsShownAlert = true;
                AlertConfig alertConfig = new AlertConfig();
                alertConfig.SetOkText(AppResources.Close);
                alertConfig.SetMessage(AppResources.NoInternet);
                alertConfig.SetAction(() => { IsShownAlert = false; });
                UserDialogs.Instance.Alert(alertConfig);
            }
        }

        public static Page GetMainPage()
        {
            return new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello, Forms !",
                    VerticalOptions =
                      LayoutOptions.CenterAndExpand,
                    HorizontalOptions =
                      LayoutOptions.CenterAndExpand,
                },
            };
        }
    }
}
