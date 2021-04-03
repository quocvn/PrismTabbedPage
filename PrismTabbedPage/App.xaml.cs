using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismTabbedPage.Views;
using Unity;
using Xamarin.Forms;

namespace PrismTabbedPage
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

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
